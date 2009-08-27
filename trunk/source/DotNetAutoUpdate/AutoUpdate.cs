using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;
using System.IO;

using log4net;
using System.Diagnostics;
using System.Globalization;

namespace DotNetAutoUpdate
{
    /// <summary>
    /// The class that checks and performs updates.
    /// </summary>
    public class AutoUpdate
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(AutoUpdate));

        public AutoUpdate()
        {
            UpdateSettings = new UpdateSettings();
        }

        /// <summary>
        /// The update settings.
        /// </summary>
        public UpdateSettings UpdateSettings { get; set; }

        /// <summary>
        /// The event triggered when an invalid signature is detected during the update process.
        /// </summary>
        public event EventHandler<InvalidSignatureEventArgs> InvalidSignatureDetected = delegate { };

        /// <summary>
        /// The latest detected pending update.
        /// </summary>
        public IList<PendingUpdate> PendingUpdates { get; private set; }

        /// <summary>
        /// Checks to see if an update is pending on the server.
        /// </summary>
        /// <returns>True if an update is pending.</returns>
        public bool IsUpdatePending()
        {
            var uri = UpdateSettings.UpdatePath.AbsoluteUri;
            var signatureUri = new Uri(uri.ToString() + ".signature");

            var webClient = new WebClient();
            var rawXml = webClient.DownloadData(uri);
            var signature = webClient.DownloadData(signatureUri);

            // Check if the signature of the update XML is valid
            if (!UpdateSettings.UpdateKeys.IsValidSignature(new MemoryStream(rawXml), signature))
            {
                log.Warn("Invalid signature detected on update XML.");
                InvalidSignatureDetected(this, new InvalidSignatureEventArgs());
                return false;
            }
            
            var xml = XDocument.Load(new StreamReader(new MemoryStream(rawXml)));
            var updates = xml
                .Descendants("Update")
                .Select(updateXml => new PendingUpdate(updateXml));

            var isUpdatePending = updates.Any(u => u.NewVersion > UpdateSettings.CurrentVersion);
            if (isUpdatePending)
            {
                log.Info("Found updated versions");
                PendingUpdates = updates.ToList();
            }
            else
            {
                log.Debug("Current version still up to date.");
            }

            return isUpdatePending;
        }

        /// <summary>
        /// Installs the given pending update.
        /// </summary>
        /// <param name="pendingUpdate">The update to install.</param>
        public void InstallPendingUpdate(PendingUpdate pendingUpdate)
        {
            log.Info("Installing update: " + pendingUpdate);
            if (pendingUpdate == null)
            {
                throw new ArgumentNullException("pendingUpdate", "No update pending");
            }

            var currentProcess = Process.GetCurrentProcess();
            var tempDirectory = string.Format(CultureInfo.InvariantCulture, "{0}-{1}-update", currentProcess.ProcessName, currentProcess.Id);
            var workingDirectory = Path.GetTempPath().PathCombine(tempDirectory);
            var installFile = pendingUpdate.InstallFileName == null
                ? "AutoUpdate.exe"
                : pendingUpdate.InstallFileName;

            var installPath = workingDirectory.PathCombine(installFile);
            var signatureUri = new Uri(pendingUpdate.UpdateFileUri.ToString() + ".signature");

            log.Debug(string.Format(CultureInfo.InvariantCulture, "Working directory:{0} install path:{1}", workingDirectory, installPath));
            Directory.CreateDirectory(workingDirectory);

            // Allow other processes to read the temp file but not write it
            using (var fileStream = new FileStream(installPath, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                var buffer = new byte[0x10000];
                var webClient = new WebClient();

                // TODO: progress updates
                // Download the install to the file
                log.Info("Downloading install file: " + pendingUpdate.UpdateFileUri);
                using (var inputStream = webClient.OpenRead(pendingUpdate.UpdateFileUri))
                {
                    var bytesRead = inputStream.Read(buffer, 0, buffer.Length);

                    while (bytesRead > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                    }
                }

                fileStream.Flush();

                // Verify the download
                log.Info("Verifying install file: " + installPath);
                var signature = webClient.DownloadData(signatureUri);
                if (!UpdateSettings.UpdateKeys.IsValidSignature(installPath, signature))
                {
                    log.Warn("Invalid signature detected on install file.");
                    InvalidSignatureDetected(this, new InvalidSignatureEventArgs());
                    return;
                }
            }

            var psi = new ProcessStartInfo()
            {
                CreateNoWindow = false,
                FileName = installPath,
                UseShellExecute = false
            };

            // Run the installer
            // NOTE: There is a possible race condition here if another user somehow manages to write to the update 
            // file before the new process starts.
            log.Info("Running install file: " + installPath);
            var process = Process.Start(psi);

            process.WaitForExit();
        }
    }
}

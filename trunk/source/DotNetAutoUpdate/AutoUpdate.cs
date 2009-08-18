using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;
using System.IO;

using log4net;

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
        public EventHandler<InvalidSignatureEventArgs> InvalidSignatureDetected = delegate { };

        /// <summary>
        /// Checks to see if an update is pending on the server.
        /// </summary>
        /// <returns>True if an update is pending.</returns>
        public bool PendingUpdate()
        {
            var uri = UpdateSettings.UpdatePath.AbsoluteUri;
            var signatureUri = new Uri(uri.ToString() + ".signature");

            var webClient = new WebClient();
            var rawXml = webClient.DownloadData(uri);
            var signature = webClient.DownloadData(signatureUri);

            // Check if the signature of the update XML is valid
            if (!UpdateSettings.UpdateKeys.IsValidSignature(rawXml, signature))
            {
                log.Warn("Invalid signature detected on update XML.");
                InvalidSignatureDetected(this, new InvalidSignatureEventArgs());
                return false;
            }
            
            var xml = XDocument.Load(new StreamReader(new MemoryStream(rawXml)));
            var rawVersion = xml
                .Descendants("Update")
                .Attributes("Version")
                .Select(a => a.Value)
                .FirstOrDefault();

            var version = new Version(rawVersion);

            var updatePending = version > UpdateSettings.CurrentVersion;
            if (updatePending)
            {
                log.Info("Found updated version: " + version);
            }
            else
            {
                log.Debug("Current version still up to date.");
            }

            return updatePending;
        }
    }
}

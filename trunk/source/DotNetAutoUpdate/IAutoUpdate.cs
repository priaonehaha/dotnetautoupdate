using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetAutoUpdate
{
    /// <summary>
    /// The interface for an update checker/installer.
    /// </summary>
    public interface IAutoUpdate
    {
        /// <summary>
        /// The update settings.
        /// </summary>
        UpdateSettings UpdateSettings { get; set; }

        /// <summary>
        /// The event triggered when an invalid signature is detected during the update process.
        /// </summary>
        event EventHandler<InvalidSignatureEventArgs> InvalidSignatureDetected;

        /// <summary>
        /// The latest detected pending update.
        /// </summary>
        IList<PendingUpdate> PendingUpdates { get; }

        /// <summary>
        /// Checks to see if an update is pending on the server.
        /// </summary>
        /// <returns>True if an update is pending.</returns>
        bool IsUpdatePending();        

        /// <summary>
        /// Installs the given pending update.
        /// </summary>
        /// <param name="pendingUpdate">The update to install.</param>
        /// <param name="downloadProgress">The action to callback with download progress updates.</param>
        /// <param name="installerStarted">The action called when the installer has started.</param>
        void InstallPendingUpdate(PendingUpdate pendingUpdate, Action<double> downloadProgress, Action installerStarted);
    }
}

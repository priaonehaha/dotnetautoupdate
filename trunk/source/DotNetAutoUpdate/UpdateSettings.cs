using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetAutoUpdate;

namespace DotNetAutoUpdate
{
    /// <summary>
    /// The update settings.
    /// </summary>
    public class UpdateSettings
    {
        /// <summary>
        /// The uri to load update XML files from.
        /// </summary>
        public Uri UpdatePath { get; set; }

        /// <summary>
        /// The current version of the program. A new version will only be installed if newer than this value.
        /// </summary>
        public Version CurrentVersion { get; set; }

        /// <summary>
        /// The update keys used to verify the update files.
        /// </summary>
        public UpdateKeys UpdateKeys { get; set; }
    }
}

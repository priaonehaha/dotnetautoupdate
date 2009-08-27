using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DotNetAutoUpdate
{
    /// <summary>
    /// Details of a pending update.
    /// </summary>
    public class PendingUpdate
    {
        public PendingUpdate()
        {
            Categories = new List<string>();
        }

        public PendingUpdate(XElement updateXml)
        {
            var rawVersion = updateXml
                   .Attributes("NewVersion")
                   .Select(a => a.Value)
                   .FirstOrDefault();

            NewVersion = new Version(rawVersion);

            var rawUpdateFileUri = updateXml
                   .Attributes("UpdateFileUri")
                   .Select(a => a.Value)
                   .FirstOrDefault();

            UpdateFileUri = new Uri(rawUpdateFileUri);

            var rawInfoFileUri = updateXml
                   .Attributes("UpdateInfoUri")
                   .Select(a => a.Value)
                   .FirstOrDefault();

            if (rawInfoFileUri != null)
            {
                UpdateInfoUri = new Uri(rawInfoFileUri);
            }

            var rawCategories = updateXml
                   .Attributes("Categories")
                   .Select(a => a.Value)
                   .FirstOrDefault();

            Categories = rawCategories == null
                ? new List<string>()
                : new List<string>(rawCategories.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

            InstallFileName = updateXml
                   .Attributes("InstallFileName")
                   .Select(a => a.Value)
                   .FirstOrDefault();
        }

        /// <summary>
        /// The new version ready for install.
        /// </summary>
        public Version NewVersion { get; set; }

        /// <summary>
        /// The update category. E.g. "beta", "stable", "x86", "x64", etc.
        /// </summary>
        public ICollection<string> Categories { get; set; }

        /// <summary>
        /// The description of the update.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The URI of a page the user can view that describes the update.
        /// </summary>
        public Uri UpdateInfoUri { get; set; }

        /// <summary>
        /// The URI of the file to download an install. E.g. http://my.tld/App.abc
        /// </summary>
        public Uri UpdateFileUri { get; set; }

        /// <summary>
        /// The name of the file to download the update file URI into and run. E.g. "App-update.exe".
        /// </summary>
        /// <remarks>If this is empty a name will be automatically generated.</remarks>
        public string InstallFileName { get; set; }
    }
}

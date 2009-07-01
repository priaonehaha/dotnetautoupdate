using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;

namespace DotNetAutoUpdateApi
{
    public class AutoUpdate
    {
        public AutoUpdate()
        {
            UpdateSettings = new UpdateSettings();
        }

        public UpdateSettings UpdateSettings { get; set; }

        public bool PendingUpdate()
        {
            var xml = XDocument.Load(UpdateSettings.UpdatePath.AbsoluteUri);
            var rawVersion = xml
                .Descendants("Update")
                .Attributes("Version")
                .Select(a => a.Value)
                .FirstOrDefault();

            var version = new Version(rawVersion);

            return version > UpdateSettings.CurrentVersion;
        }
    }
}

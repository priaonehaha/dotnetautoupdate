using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Linq;
using System.IO;

namespace DotNetAutoUpdate
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
            var uri = UpdateSettings.UpdatePath.AbsoluteUri;
            var signatureUri = new Uri(uri.ToString() + ".signature");

            var webClient = new WebClient();
            var rawXml = webClient.DownloadData(uri);
            var signature = webClient.DownloadData(signatureUri);

            //if (UpdateSettings.PublicKey.IsValidSignature(

            var xml = XDocument.Load(new StreamReader(new MemoryStream(rawXml)));
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

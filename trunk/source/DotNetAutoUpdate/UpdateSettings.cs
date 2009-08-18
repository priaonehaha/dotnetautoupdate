using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetAutoUpdate;

namespace DotNetAutoUpdate
{
    public class UpdateSettings
    {
        public Uri UpdatePath { get; set; }
        public Version CurrentVersion { get; set; }
        public KeyPair PublicKey { get; set; }
    }
}

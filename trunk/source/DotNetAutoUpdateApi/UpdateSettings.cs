using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetAutoUpdateApi
{
    public class UpdateSettings
    {
        public Uri UpdatePath { get; set; }
        public Version CurrentVersion { get; set; }
    }
}

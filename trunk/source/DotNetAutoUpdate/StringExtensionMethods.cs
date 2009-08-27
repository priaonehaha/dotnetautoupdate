using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace DotNetAutoUpdate
{
    public static class StringExtensionMethods
    {
        public static string PathCombine(this string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }
    }
}

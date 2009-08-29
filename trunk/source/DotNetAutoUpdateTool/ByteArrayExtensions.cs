using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetAutoUpdateTool
{
    public static class ByteArrayExtensions
    {
        public static string ToHexString(this byte[] data)
        {
            var result = new StringBuilder();
            var count = 0;

            foreach (var b in data)
            {
                result.AppendFormat("{0:x2} ", b);
                count++;

                if (count % 16 == 0)
                {
                    result.AppendLine();
                }
            }

            return result.ToString();
        }
    }
}

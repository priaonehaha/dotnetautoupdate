using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace DotNetAutoUpdate
{
    public static class WebClientExtensions
    {
        [CoverageExclude]
        public static bool TryGetContentLength(this WebClient webClient, out long length)
        {
            var lengthString = webClient.ResponseHeaders.Get("Content-Length");

            if (lengthString == null)
            {
                length = 0;
                return false;
            }

            return long.TryParse(lengthString, out length);
        }
    }
}

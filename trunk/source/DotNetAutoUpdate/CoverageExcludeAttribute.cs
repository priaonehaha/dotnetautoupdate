using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetAutoUpdate
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Constructor)]
    public sealed class CoverageExcludeAttribute : Attribute
    {
        public CoverageExcludeAttribute()
        {
        }

        public CoverageExcludeAttribute(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Config;
using NUnit.Framework;

namespace DotNetAutoUpdate.Tests
{
    public abstract class BaseFixture
    {        
        [TestFixtureSetUp]
        public virtual void FixtureSetup()
        {
            BasicConfigurator.Configure();
        }
    }
}

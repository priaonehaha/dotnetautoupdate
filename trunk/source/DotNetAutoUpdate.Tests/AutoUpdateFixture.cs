using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using DotNetAutoUpdate.Tests;

namespace DotNetAutoUpdate.Tests
{
    [TestFixture]
    public class AutoUpdateFixture
    {
        AutoUpdate _autoUpdate;
        WebServer _webServer;

        [SetUp]
        public void Setup()
        {
            _webServer = new WebServer(new FileInfo(Path.Combine(Environment.CurrentDirectory, @"..\..\Source\DotNetAutoUpdate.Tests\Data")).FullName);            
            _autoUpdate = new AutoUpdate();
        }

        [Test]
        public void Should_detect_pending_update()
        {
            _autoUpdate.UpdateSettings.UpdatePath = new Uri(_webServer.Uri, "update-file-1.1.0.0.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.0.0.0");

            var result = _autoUpdate.PendingUpdate();

            Assert.That(result, Is.True);
        }

        [Test]
        public void Should_ignore_stale_update()
        {
            _autoUpdate.UpdateSettings.UpdatePath = new Uri(_webServer.Uri, "update-file-1.1.0.0.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.1.0.0");

            var result = _autoUpdate.PendingUpdate();

            Assert.That(result, Is.False);
        }

        [Test]
        public void Should_ignore_blob_with_invalid_signature()
        {
            _autoUpdate.UpdateSettings.UpdatePath = new Uri(_webServer.Uri, "update-file-1.1.0.0-invalid.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.0.0.0");

            var result = _autoUpdate.PendingUpdate();

            Assert.That(result, Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            _webServer.Dispose();
        }
    }
}

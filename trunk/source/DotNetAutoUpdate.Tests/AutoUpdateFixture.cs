using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using DotNetAutoUpdate.Tests;
using System.Net.Sockets;
using System.Net;

namespace DotNetAutoUpdate.Tests
{
    [TestFixture]
    public class AutoUpdateFixture : BaseFixture
    {
        AutoUpdate _autoUpdate;
        WebServer _webServer;

        [SetUp]
        public void Setup()
        {
            _webServer = new WebServer(new FileInfo(Path.Combine(Environment.CurrentDirectory, @"..\..\Source\DotNetAutoUpdate.Tests\Data")).FullName, 12345);            
            _autoUpdate = new AutoUpdate();
            _autoUpdate.UpdateSettings.UpdateKeys = UpdateKeys.FromStrongNameKey("Data\\TestKeyPair.snk");
        }

        [Test]
        public void Should_detect_pending_update()
        {
            _autoUpdate.UpdateSettings.UpdatePath = new Uri(_webServer.Uri, "update-file-1.1.0.0.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.0.0.0");

            var result = _autoUpdate.IsUpdatePending();

            Assert.That(result, Is.True);
        }

        [Test]
        public void Should_ignore_stale_update()
        {
            _autoUpdate.UpdateSettings.UpdatePath = new Uri(_webServer.Uri, "update-file-1.1.0.0.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.1.0.0");

            var result = _autoUpdate.IsUpdatePending();

            Assert.That(result, Is.False);
        }

        [Test]
        public void Should_ignore_blob_with_invalid_signature()
        {
            _autoUpdate.UpdateSettings.UpdatePath = new Uri(_webServer.Uri, "update-file-1.1.0.0-invalid.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.0.0.0");

            var result = _autoUpdate.IsUpdatePending();

            Assert.That(result, Is.False);
        }

        [Test]
        public void Should_notify_on_invalid_signature()
        {
            var invalidSignatureNotified = false;

            _autoUpdate.UpdateSettings.UpdatePath = new Uri(_webServer.Uri, "update-file-1.1.0.0-invalid.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.0.0.0");
            _autoUpdate.InvalidSignatureDetected += delegate
            {
                invalidSignatureNotified = true;
            };

            var result = _autoUpdate.IsUpdatePending();

            Assert.That(result, Is.False);
            Assert.That(invalidSignatureNotified, Is.True);
        }

        [Test]
        public void Should_run_installer_application()
        {
            _autoUpdate.UpdateSettings.UpdatePath = new Uri(_webServer.Uri, "update-file-1.1.0.0.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.0.0.0");
            _autoUpdate.InvalidSignatureDetected += delegate        
            {
                Assert.Fail("Invalid signature detected");
            };

            using (var socketListener = new SocketListener("Hello from: AutoUpdate\r\n"))
            {
                var acceptResult = socketListener.Listen();
                var updatePending = _autoUpdate.IsUpdatePending();
                _autoUpdate.InstallPendingUpdate(_autoUpdate.PendingUpdates[0]);

                Assert.That(updatePending, Is.True);
                Assert.That(acceptResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(10)), Is.True, "Timed out waiting for installer to call back");
            }
        }

        [Test]
        public void Should_run_installer_application_with_custom_name()
        {
            _autoUpdate.UpdateSettings.UpdatePath = new Uri(_webServer.Uri, "update-file-custom-name-1.1.0.0.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.0.0.0");
            _autoUpdate.InvalidSignatureDetected += delegate
            {
                Assert.Fail("Invalid signature detected");
            };

            using (var socketListener = new SocketListener("Hello from: Custom\r\n"))
            {
                var acceptResult = socketListener.Listen();
                var updatePending = _autoUpdate.IsUpdatePending();
                _autoUpdate.InstallPendingUpdate(_autoUpdate.PendingUpdates[0]);

                Assert.That(updatePending, Is.True);
                Assert.That(acceptResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(10)), Is.True, "Timed out waiting for installer to call back");
            }
        }

        [Test]
        public void Should_not_run_installer_with_invalid_sig()
        {
            bool invalidSigDetected = false;
            _autoUpdate.UpdateSettings.UpdatePath = new Uri(_webServer.Uri, "update-invalid-file-sig-1.1.0.0.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.0.0.0");
            _autoUpdate.InvalidSignatureDetected += delegate
            {
                invalidSigDetected = true;
            };


            using (var socketListener = new SocketListener(null))
            {
                var acceptResult = socketListener.Listen();
                var updatePending = _autoUpdate.IsUpdatePending();
                _autoUpdate.InstallPendingUpdate(_autoUpdate.PendingUpdates[0]);

                Assert.That(updatePending, Is.True);
                Assert.That(acceptResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(10)), Is.False, "Expected to time out waiting for installer to call back");
                Assert.That(invalidSigDetected, Is.True, "Expected invalid signature");
            }
        }

        [Test]
        public void Should_fail_if_no_update_specified()
        {
            try
            {
                _autoUpdate.InstallPendingUpdate(null);

                Assert.Fail("Expected exception");
            }
            catch (ArgumentNullException)
            {
                // Ignore, expected
            }
        }

        [Test]
        public void Should_return_false_on_server_missing()
        {
            var invalidUri = new Uri(_webServer.Uri, "bogus-path/");
            _autoUpdate.UpdateSettings.UpdatePath = new Uri(invalidUri, "update-file-1.1.0.0.xml");
            _autoUpdate.UpdateSettings.CurrentVersion = new Version("1.0.0.0");

            var result = _autoUpdate.IsUpdatePending();

            Assert.That(result, Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            _webServer.Dispose();
        }
    }

    public class SocketListener : IDisposable
    {
        private Socket _socket;

        private string _expectedText;

        public SocketListener(string expectedText)
        {
            _expectedText = expectedText;
        }

        public bool Error { get; private set; }

        public IAsyncResult Listen()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(IPAddress.Loopback, 5050));
            _socket.Listen(1);

            return _socket.BeginAccept(delegate(IAsyncResult asyncResult)
            {
                try
                {
                    var client = _socket.EndAccept(asyncResult);

                    using (var networkStream = new NetworkStream(client))
                    using (var streamReader = new StreamReader(networkStream))
                    {
                        Assert.That(streamReader.ReadToEnd(), Is.EqualTo(_expectedText));
                    }

                }
                catch (ObjectDisposedException)
                {
                    Error = true;
                }

            }, null);
        }

        public void Dispose()
        {
            if (_socket != null)
            {
                ((IDisposable) _socket).Dispose();
            }
        }
    }
}

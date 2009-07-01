using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.WebHost;

namespace DotNetAutoUpdate.Tests
{
    [CoverageExclude]
    public class WebServer : IDisposable
    {
        private Server _server;

        private int _port;

        public WebServer(string pathToWebApplication) :
            this(pathToWebApplication, BasePort + new Random().Next(20))
        {
        }

        public WebServer(string pathToWebApplication, int port)
        {
            _port = port;
            _server = new Server(port, "/", pathToWebApplication);
            _server.Start();
        }

        ~WebServer()
        {
            Dispose(false);
        }

        public Uri Uri { get { return new Uri("http://localhost:" + _port); } }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                if (_server != null)
                {
                    _server.Stop();
                    _server = null;
                }
            }
        }

        #endregion

        public const int BasePort = 12008;
    }
}

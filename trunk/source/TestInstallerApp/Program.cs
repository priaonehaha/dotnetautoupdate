using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace TestInstallerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Connect(new IPEndPoint(IPAddress.Loopback, 5050));

                    using (var networkStream = new NetworkStream(socket))
                    using (var writer = new StreamWriter(networkStream))
                    {
                        writer.WriteLine("Hello from test installer");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine("Failed to connect: " + ex.Message);
            }
        }
    }
}

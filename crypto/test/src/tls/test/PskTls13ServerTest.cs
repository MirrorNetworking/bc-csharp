﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using NUnit.Framework;

using Mirror.BouncyCastle.Utilities.IO;

namespace Mirror.BouncyCastle.Tls.Tests
{
    [TestFixture]
    public class PskTls13ServerTest
    {
        [Test, Explicit]
        public void TestConnection()
        {
            int port = 5556;

            TcpListener ss = new TcpListener(IPAddress.Any, port);
            ss.Start();
            Stream stdout = Console.OpenStandardOutput();
            try
            {
                while (true)
                {
                    TcpClient s = ss.AcceptTcpClient();
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Accepted " + s);
                    ServerTask serverTask = new ServerTask(s, stdout);
                    Thread t = new Thread(new ThreadStart(serverTask.Run));
                    t.Start();
                }
            }
            finally
            {
                ss.Stop();
            }
        }

        internal class ServerTask
        {
            private readonly TcpClient s;
            private readonly Stream stdout;

            internal ServerTask(TcpClient s, Stream stdout)
            {
                this.s = s;
                this.stdout = stdout;
            }

            public void Run()
            {
                try
                {
                    MockPskTls13Server server = new MockPskTls13Server();
                    TlsServerProtocol serverProtocol = new TlsServerProtocol(s.GetStream());
                    serverProtocol.Accept(server);
                    Stream log = new TeeOutputStream(serverProtocol.Stream, stdout);
                    Streams.PipeAll(serverProtocol.Stream, log);
                    serverProtocol.Close();
                }
                finally
                {
                    try
                    {
                        s.Close();
                    }
                    catch (IOException)
                    {
                    }
                }
            }
        }
    }
}

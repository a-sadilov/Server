using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Timers;

namespace Server
{
    class SocketServer
    {
        private static readonly IPAddress _serverIp = (Dns.GetHostEntry(Dns.GetHostName())).AddressList[1];
        private static int _serverPort;
        private static Socket _listenSocket;
        private static int counter = 0;
        private static int iterator = 0;
        private static List<Socket> TcpClients = new List<Socket>();
        private static System.Timers.Timer _counterTimer;
        public static IPAddress ServerIp { get { return _serverIp; } }
        public static string ServerPort
        {
            get { return _serverPort.ToString(); }
            set
            {
                try
                {
                    SocketServer._serverPort = int.Parse(value);
                }
                catch
                {
                    throw new Exception("Entered string was not converted to Port");
                }
            }
        }

        public SocketServer()
        {
            _serverPort = 8000;
            IPEndPoint _serverIpEndPoint = new IPEndPoint(ServerIp, _serverPort);
            _listenSocket = new Socket(AddressFamily.InterNetwork,
                                                    SocketType.Stream,
                                                    ProtocolType.Tcp);
            _listenSocket.Bind(_serverIpEndPoint);
        }

        public SocketServer(string serverPort)
        {
            ServerPort = serverPort;
            IPEndPoint _serverIpEndPoint = new IPEndPoint(ServerIp, _serverPort);
             _listenSocket = new Socket(AddressFamily.InterNetwork,
                                                    SocketType.Stream,
                                                    ProtocolType.Tcp);
            _listenSocket.Bind(_serverIpEndPoint);
        }

        public static void AddClient(Socket client)
        {
            TcpClients.Add(client);
        }
        public static void RemoveClient(Socket client)
        {
            TcpClients.Remove(client);
        }
        public static void SetTimer()
        {
            _counterTimer = new System.Timers.Timer(1000);
            _counterTimer.Elapsed += OnTimedEvent;
            _counterTimer.Start();
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            iterator += 1;
            Console.WriteLine(iterator);
            foreach (Socket a in TcpClients)
            {
                var data = Encoding.UTF8.GetBytes(iterator.ToString());
                a.Send(data);
            }
        }

        public static void Start()
        {
            _listenSocket.Listen(1000);
            Console.WriteLine(">> Server started");
            while (true)
            {
                SocketServer.counter += 1;
                Socket clientSocket = _listenSocket.Accept();
                Console.WriteLine($">> Client No: {0} accepted", counter);
                new Thread(() => ConnectClient(clientSocket)).Start();
            }
        }

        public static void ConnectClient(Socket client)
        {
            counter++;
            Console.WriteLine($">> New client No:{0} " + client, counter);
            TcpClients.Add(client);
            while (client.Connected)
            {
                try 
                { 
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[32];
                    do
                    {
                        bytes = client.Receive(data);
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    } while (client.Available > 0);

                    string message = builder.ToString();
                        if (message != "")
                        {
                            Console.WriteLine($">> Client No:{0} sended:" + DateTime.Now.ToShortTimeString() + message, counter);
                            switch (message)
                            {
                                case ("Start"):
                                    if (_counterTimer == null)
                                    {
                                        new Thread(() => SetTimer()).Start();
                                    }
                                    else { _counterTimer.Start(); }
                                    break;
                                case ("Stop"):
                                    if (_counterTimer != null)
                                    {
                                        _counterTimer.Stop();
                                    }
                                    else { break; }
                                    break;
                                case ("Clear"):
                                    if (_counterTimer != null)
                                    {
                                        iterator = 0;
                                        _counterTimer.Stop();
                                    }
                                    break;
                            }
                        }
                }
                catch (Exception e)
                {
                }
            }
            TcpClients.Remove(client);
            
            Console.WriteLine($">> Client No:{0} " + client + "closed", counter);
        }
    }
}

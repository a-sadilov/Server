using System;
using System.Net;

namespace Server
{
    class WebSocketServer
    {
        private static IPAddress _serverIp = (Dns.GetHostEntry(Dns.GetHostName())).AddressList[1];
        private static int _serverPort;
        private static WebSocketSharp.Server.WebSocketServer _wssv; 
        public static IPAddress ServerIp { get { return _serverIp; } }
        public static string ServerPort
        {
            get { return _serverPort.ToString(); }
            set
            {
                try
                {
                    WebSocketServer._serverPort = int.Parse(value);
                }
                catch
                {
                    throw new Exception("Entered string was not converted to Port");
                }
            }
        }
        public WebSocketServer()
        {
            _serverIp = (Dns.GetHostEntry(Dns.GetHostName())).AddressList[1];
            _serverPort = 8000;
            _wssv = new WebSocketSharp.Server.WebSocketServer(_serverIp, _serverPort);
            _wssv.AddWebSocketService<ServerCounter>("/ServerCounter");

        }

        public WebSocketServer(string serverPort)
        {
            ServerPort = serverPort;
            _wssv = new WebSocketSharp.Server.WebSocketServer(ServerIp, _serverPort);
            _wssv.AddWebSocketService<ServerCounter>("/ServerCounter");
        }
        public static void Start()
        {
            _wssv?.Start();
            Console.WriteLine(">> Server started");
        }
        public static void Stop()
        {
            _wssv?.Stop();
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Timers;
namespace Server
{
    class TcpServer
    {
        
        private readonly static IPAddress _localIPAddr = IPAddress.Any;
        private static List<TcpClient> TcpClients = new List<TcpClient>();
        private static Timer _counterTimer = null;
        private static int _serverPort = 8000;
        private TcpClient _incommingClient;
        private static TcpListener _listener;

        public static IPAddress ServerIp { get { return _localIPAddr; } }
        public static string ServerPort
        {
            get { return _serverPort.ToString(); }
            set
            {   try
                {
                    TcpServer._serverPort = int.Parse(value);
                }
                catch
                {
                    throw new Exception("Entered string was not converted to Port");
                }
            }
        }

        public TcpServer(string port)
        {
            ServerPort = port;
            _listener = new TcpListener(ServerIp, _serverPort);
        }
        public static void PrintList() => Console.WriteLine(TcpClients);
        public static void AddClient(TcpClient client)
        {
            TcpClients.Add(client);
        }
        public static void RemoveClient(TcpClient client)
        {
            TcpClients.Remove(client);
        }
        
        public void ListenIncommingRequests(TcpListener _listener)
        {
            
            _listener.Server.Accept();
            _incommingClient = _listener.AcceptTcpClient();
            if (!TcpClients.Contains(_incommingClient))
            { 
                TcpClients.Add(_incommingClient);
            }
            Console.WriteLine("Incomming call from {0} has just been accepted. Processing request...", _incommingClient.Client.RemoteEndPoint);

            Task.Factory.StartNew(() => this.ProcessRequest(_incommingClient));
            
        }


        public void ProcessRequest(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                this.ProcessRequest(stream);
            }
        }
        
        public void ListenAsync()
        {
            try
            {
                
                _listener.Start();
                Console.WriteLine("Server has started at the port {0}", ServerPort);
                ListenIncommingRequests(_listener);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void ProcessRequest(NetworkStream stream)
        {
            try
            {
                byte[] bytesForData = new byte[12];
                stream.Read(bytesForData, 0, bytesForData.Length);
                string message = Encoding.UTF8.GetString(bytesForData);

                switch (message)
                {
                    case ("Start"):
                        if (_counterTimer == null)
                        {
                            _counterTimer = new Timer(1000);
                            _counterTimer.Start();
                        }
                        else { _counterTimer.Start(); }
                        SendResponse(_counterTimer.ToString(), stream);
                        break;
                    case ("Stop"):
                        _counterTimer.Stop();
                        SendResponse(_counterTimer.ToString(), stream);

                        break;
                    case ("Clear"):
                        if (_counterTimer != null) { _counterTimer.Close(); }
                        break;
                    
                }
                string reponse = string.Format("200OK_\"{0}\"", message);
                SendResponse(reponse, stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void SendResponse(string response, NetworkStream stream)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(response);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}

using System;

namespace Server
{

    class Server
    {
        static void Main(string[] args)
        {
        initialize:
            try
            {
                Console.WriteLine("Enter server port: (example: 8000)");
                string port = Console.ReadLine();
                Console.WriteLine("Enter the server Type: (example: Socket, WebSocket)");
                string type = Console.ReadLine();
                if(type == "Socket")
                {
                    SocketServer server = new SocketServer(port);
                    SocketServer.Start();
                }
                if (type == "WebSocket")
                {
                    WebSocketServer ws = new WebSocketServer(port);
                    WebSocketServer.Start();
                    Console.ReadLine();
                    WebSocketServer.Stop();
                }
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Enter correct server Type: (example: Socket, WebSocket)");
                goto initialize;
            }

        }

    }
}

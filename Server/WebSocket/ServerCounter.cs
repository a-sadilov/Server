using Newtonsoft.Json;
using Server.WebSocket.Core;
using System;
using System.Threading;
using System.Timers;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace Server
{
    public class ServerCounter : WebSocketBehavior
    {
        private static System.Timers.Timer _counterTimer;
        private static int iterator = 0;

        protected override void OnOpen()
            => Console.WriteLine($"Client Connected: {ID}");

        protected override void OnClose(CloseEventArgs e)
            => Console.WriteLine($"Client Disconnected: {ID}");

        protected override void OnError(ErrorEventArgs e)
        {
            Console.WriteLine($"ERROR: {e.Message}");
            Console.WriteLine($"EXCEPTION: {e.Exception}");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine($"Server Received Message From {ID}: {e.Data}");
            ParseJson(e.Data);
        }
        public void SetTimer()
        {
            _counterTimer = new System.Timers.Timer(1000);
            _counterTimer.Elapsed += OnTimedEvent;
            _counterTimer.Start();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            iterator += 1;
            Console.WriteLine(iterator);
            CurrentCount msg = new CurrentCount
            {
                counter = iterator
            };
            string json = JsonConvert.SerializeObject(msg);
            Sessions.Broadcast(json);
        }
        private void ParseJson(string json)
        {
            var request = JsonConvert.DeserializeObject<ClientCommand>(json);
            var op = (Command)request.command;

            switch (op)
            {
                case Command.Start:
                    if (_counterTimer == null)
                    {
                        new Thread(() => SetTimer()).Start();
                    }
                    else { _counterTimer.Start(); }
                    break;
                case Command.Stop:
                    if (_counterTimer != null)
                    {
                        _counterTimer.Stop();
                    }
                    else { break; }
                    break;
                case Command.Clear:
                    if (_counterTimer != null)
                    {
                        iterator = 0;
                        _counterTimer.Stop();
                    }
                    break;
            }
        }
    }
}

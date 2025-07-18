using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Protection.PlayReady;
using Windows.Networking.Sockets;

namespace RiftReady.Assist.LOL.LCU
{
    public class LCUSocket
    {
        private ClientWebSocket? Client { get; set; } = null;
        public string Port { get; private set; } = string.Empty;
        public string Token { get; private set; } = string.Empty;

        private Uri? Uri = null;

        protected bool IsOpen { get { return Client?.State == WebSocketState.Open; } }

        public bool Connect(string port, string username, string password)
        {
            Abort();
            var bytes = Encoding.UTF8.GetBytes($"{username}:{password}");
            Token = Convert.ToBase64String(bytes);
            Port = port;

            Uri = new Uri($"wss://127.0.0.1:{Port}/");
            Client = new ClientWebSocket();

            Client.Options.KeepAliveInterval = TimeSpan.FromSeconds(30);
            Client.Options.SetRequestHeader("Authorization", $"Basic {Token}");
            Client.ConnectAsync(Uri, CancellationToken.None).Wait();
            
            return true;
        }


        public void Abort()
        {
            Client?.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None).Wait();
            Client?.Dispose();
            Client = null;
        }


        public async Task Send(string message)
        {
            if (!IsOpen)
            {
                await Client!.ConnectAsync(Uri!, CancellationToken.None);
            } else
            {
                ArraySegment<byte> data = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
                await Client!.SendAsync(data, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }


    }
}

using RiftReady.Assist.Http;
using System.Text;

namespace RiftReady.Assist.LOL.LCU
{
    public class LCUAccess : HttpAccess
    {
        public string Port { get; private set; } = string.Empty;
        public string Token { get; private set; } = string.Empty;

        public void Update(string port, string username, string password)
        {
            var bytes = Encoding.UTF8.GetBytes($"{username}:{password}");
            Token = Convert.ToBase64String(bytes);
            Port = port;
            Domain = $"https://127.0.0.1:{port}/"; 
            Header("Authorization", $"Basic {Token}");
        }
    }
}

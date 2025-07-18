using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RiftReady.Assist.Server
{
    public class ServerRecv(HttpListenerRequest request)
    {
        public string? Header(string name) => request.Headers.Get(name);

        public T? Json<T>() where T : class => JsonSerializer.Deserialize<T>(request.InputStream);

        public string Method { get { return request.HttpMethod; } }

        public string? Url { get { return request.Url?.AbsolutePath; } }

        public string? RawUrl { get { return request.RawUrl; } }

        public string? Param(string name) => request.QueryString.Get(name);
    }
}

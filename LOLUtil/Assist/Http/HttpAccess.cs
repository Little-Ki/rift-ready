using System.Net;
using System.Text.Json.Nodes;

namespace LOLUtil.Assist.Http
{
    public class HttpAccess : IDisposable
    {
        private readonly HttpClient httpClient;
        private readonly HttpClientHandler clientHandler;
        private readonly CookieContainer cookieJar;

        public string Domain { get => httpClient.BaseAddress?.ToString() ?? string.Empty; set => httpClient.BaseAddress = new(value); }

        private Task<HttpResult> RequestAsync(HttpRequestMessage message)
        {
            var task = new Task<HttpResult>(() =>
            {
                try
                {
                    var response = httpClient.SendAsync(message).Result;
                    return new(response);
                }
                catch
                {
                    return new(new(HttpStatusCode.NotFound));
                }
            });

            task.Start();

            return task;
        }

        public HttpAccess()
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            clientHandler = new()
            {
                Proxy = null,
                AllowAutoRedirect = true,
                UseCookies = true,
                CookieContainer = cookieJar = new(),
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            httpClient = new(clientHandler, true);
        }

        public void Cookie(string domain, string value)
        {
            value
                .Replace(" ", "")
                .Split(';')
                .Select(x => x.Split('='))
                .Where(x => x.Length == 2)
                .ToList()
                .ForEach(x => cookieJar.Add(new Cookie(x[0], x[1]) { Domain = domain }));
        }

        public void Proxy(string? address = null)
        {
            if (address == null)
            {
                clientHandler.Proxy = null;
            }
            else
            {
                clientHandler.Proxy = new WebProxy()
                {
                    Address = new Uri(address),
                    BypassProxyOnLocal = false
                };
            }
        }

        public void Header(string key, string value)
        {
            httpClient.DefaultRequestHeaders.Add(key, value);
        }

        public Task<HttpResult> Send(string method, string url, HttpContent? content = null, Dictionary<string, string>? headers = null)
        {
            var _method = method.ToUpper() switch
            {
                "POST" => HttpMethod.Post,
                "GET" => HttpMethod.Get,
                "HEAD" => HttpMethod.Head,
                "PUT" => HttpMethod.Put,
                "PATCH" => HttpMethod.Patch,
                "OPTION" => HttpMethod.Options,
                "DELETE" => HttpMethod.Delete,
                "TRACE" => HttpMethod.Trace,
                _ => throw new Exception("Invalid http method")
            };

            HttpRequestMessage message = new(_method, url)
            {
                Content = content
            };

            foreach (var it in headers ?? [])
            {
                message.Headers.Add(it.Key, it.Value);
            }

            return RequestAsync(message);
        }

        public void Dispose() => httpClient.Dispose();
    }
}

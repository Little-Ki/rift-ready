using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LOLUtil.Assist.Server
{
    public class HttpServer
    {
        private class HandlerRecord
        {
            public required string Method;

            public required string Path;

            public required RequestHandler Handler;
        };

        private readonly List<HandlerRecord> handlers = [];

        private readonly Thread thread;

        private readonly HttpListener serverListner;

        private bool isContinue = false;

        private short port = 2345;
        public string Url { get { return $"http://localhost:{port}/"; } }

        public delegate void RequestHandler(ServerRecv request, ServerSend response);
        public HttpServer(short port = 2345)
        {
            this.port = port;

            serverListner = new();
            serverListner.Prefixes.Add(Url);

            thread = new(new ThreadStart(Run));
        }

        private void Run()
        {
            while (isContinue)
            {
                try
                {
                    HttpListenerContext context = serverListner.GetContext();
                    ServerRecv recv = new(context.Request);
                    ServerSend send = new(context.Response);

                    var method = recv.Method;
                    var path = recv.Url ?? "/";

                    var find = handlers
                        .Where(x =>
                        x.Method.Equals(method, StringComparison.InvariantCultureIgnoreCase) &&
                        Regex.Match(path, $"^{x.Path}$").Length > 0
                    );

                    if (find.Any())
                    {
                        find.First().Handler(recv, send);
                    }

                    send.Post();
                    send.Close();
                }
                catch
                {
                    break;
                }
            }
        }

        public void Start()
        {
            if (thread.IsAlive)
            {
                return;
            }

            isContinue = true;
            serverListner.Start();
            thread.Start();
        }

        public void Stop()
        {
            isContinue = false;
            serverListner.Close();
            thread.Join();
        }

        public HttpServer Register(string method, string path, RequestHandler handler)
        {
            handlers.Add(new()
            {
                Path = path,
                Method = method,
                Handler = handler
            });
            return this;
        }

        public bool Browse()
        {
            List<ProcessStartInfo> tests = new() {
                new()
                {
                    UseShellExecute = true,
                    FileName = "msedge.exe",
                    Arguments = $"--app={Url} --window-size=450,750 --window-name=\"WTF\""
                },
                new()
                {
                    UseShellExecute = true,
                    FileName = "chrome.exe",
                    Arguments = $"--app={Url} --window-size=450,750"
                }
            };

            foreach (var it in tests)
            {
                try
                {

                    Process.Start(it);
                    return true;
                }
                catch { }
            }

            return false;
        }
    }
}

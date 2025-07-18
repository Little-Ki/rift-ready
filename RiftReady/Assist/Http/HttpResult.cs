using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace RiftReady.Assist.Http
{
    public class HttpResult(HttpResponseMessage message)
    {
        public byte[] Data
        {
            get
            {
                return message.Content.ReadAsByteArrayAsync().Result;
            }
        }

        public string Text
        {
            get
            {
                return message.Content.ReadAsStringAsync().Result;
            }
        }

        public HttpStatusCode Status
        {
            get
            {
                return message.StatusCode;
            }
        }

        public bool Success
        {
            get
            {
                return Status == HttpStatusCode.OK || Status == HttpStatusCode.PartialContent;
            }
        }

        public IEnumerable<string> Header(string name) {
            var dictionary = message.Headers.ToDictionary();

            if (dictionary.TryGetValue(name, out IEnumerable<string>? value))
            {
                return value;
            }

            return [];
        }

        public readonly JsonWrapper Json = new(message.Content.ReadAsStringAsync().Result);

    };

}

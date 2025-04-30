using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LOLUtil.Core.Controller
{
    public class Response
    {
        [property: JsonPropertyName("code")]
        public int Code { get; set; } = 200;

        [property: JsonPropertyName("message")]
        public string Message { get; set; } = "OK";
    }

    public class ResponseObject<T> : Response where T : class
    {
        [property: JsonPropertyName("data")]
        public required T Data { get; set; }
    }

    public class ResponseValue<T> : Response where T : struct
    {
        [property: JsonPropertyName("data")]
        public required T Data { get; set; }
    }
}

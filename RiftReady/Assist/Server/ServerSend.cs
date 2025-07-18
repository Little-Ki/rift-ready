using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LOLUtil.Assist.Server
{
    public class ServerSend
    {
        private readonly HttpListenerResponse response;
        public byte[] Data { get; private set; } = [];
        public void Json<T>(T value, int statusCode = 200) where T : class
        {
            Data = JsonSerializer.SerializeToUtf8Bytes(value);
            response.ContentType = "application/json";
            response.ContentLength64 = Data.Length;
            response.StatusCode = statusCode;
        }

        public void Text(string value, string contentType = "text/html", int statusCode = 200)
        {
            Data = Encoding.UTF8.GetBytes(value);
            response.ContentLength64 = Data.Length;
            response.ContentType = contentType;
            response.StatusCode = statusCode;
        }

        public void Header(string name, string value) => response.Headers.Set(name, value);

        public int StatusCode { get { return response.StatusCode; } set { response.StatusCode = value; } }
        public ServerSend(HttpListenerResponse response)
        {
            this.response = response;
            response.ContentEncoding = Encoding.UTF8;
            response.StatusCode = 200;
            response.ContentType = "text/html";
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
        }

        public void Post() => response.OutputStream.Write(Data);
        public void Close() => response.Close();
    }
}

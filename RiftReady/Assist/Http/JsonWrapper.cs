using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LOLUtil.Assist.Http
{
    public class JsonWrapper
    {
        public readonly JsonNode? Root;

        private JsonNode? Node(params dynamic[] path)
        {
            var node = Root;

            foreach (var it in path)
            {
                if (node == null)
                    return null;
                node = node[it];
            }

            return node;
        }

        public JsonWrapper(string content)
        {
            try
            {
                Root = JsonNode.Parse(content);
            } catch
            {
                Root = null;
            }
        }

        public T? Array<T>(params dynamic[] path) where T : class
        {
            try
            {
                return Node(path)!.AsArray().Deserialize<T>();
            }
            catch
            {
                return null;
            }
        }

        public T Value<T>(params dynamic[] path) where T : struct
        {
            try
            {
                return Node(path)!.GetValue<T>();
            } catch
            {
                return default;
            }
        }

        public T? Object<T>(params dynamic[] path) where T : class
        {
            try
            {
                return Node(path)!.AsObject().Deserialize<T>();
            } catch
            {
                return null;
            }
        }
    }
}

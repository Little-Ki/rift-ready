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

        public JsonNode? Node(params dynamic[] path)
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
    }
}

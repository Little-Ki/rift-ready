using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Management;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace LOLUtil.Utils
{
    public static class Misc
    {
        public static string? Match(string input, string pattern, int index, int in_group)
        {
            var match = Regex.Matches(input, pattern);

            if (match.Count < index + 1)
            {
                return null;
            }

            if (match[index].Groups.Count < in_group + 1)
            {
                return null;
            }

            return match[index].Groups[in_group].Value;
        }
        public static List<string> ExplodeString(string value)
        {
            if (value.Equals(string.Empty))
                return [];

            var iter = StringInfo.GetTextElementEnumerator(value.Normalize());
            List<string> result = [];

            while (iter.MoveNext())
            {
                result.Add(iter.GetTextElement());
            }

            return result;
        }

        public static T? ReadJson<T>(string path) where T : class
        {
            try
            {
                using StreamReader inFile = new(path);
                return JsonSerializer.Deserialize<T>(inFile.ReadToEnd()) ?? null;
            }
            catch
            {
                return null;
            }
        }

        public static bool WriteJson<T>(T value, string path)
        {
            try
            {
                using StreamWriter outFile = new StreamWriter(path);
                outFile.Write(JsonSerializer.Serialize(value));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string DecodeBase64(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            byte[] bytes = Convert.FromBase64String(value);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string EncodeBase64(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

    }
}

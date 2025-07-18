using Microsoft.Toolkit.Uwp.Notifications;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;


namespace RiftReady.Assist
{
    public static class Utils
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

        public static void Notification(string title, string content)
        {
            new ToastContentBuilder()
                        .AddArgument("action", "viewConversation")
                        .AddArgument("conversationId", 9813)
                        .AddText(title)
                        .AddText(content)
                        .SetToastDuration(ToastDuration.Long)
                        .SetToastScenario(ToastScenario.Reminder)
                        .Show();
        }
    }
}

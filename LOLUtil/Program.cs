using LOLUtil.Assist.Http;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LOLUtil
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
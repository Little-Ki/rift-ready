using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RiftReady.Assist
{
    public static class ProcessFinder
    {
        public static Process? GetProcess(string processName)
        {
            var processes = Process.GetProcesses()
                .Where(x => x.ProcessName.Equals(processName));

            return processes.Any() ? processes.First() : null;
        }

        public static bool IsProcess(int processId)
        {
            return Process.GetProcesses()
                .Any(x => x.Id == processId);
        }

        public static Dictionary<string, string> ProcessCMD(Process process)
        {
            using ManagementObjectSearcher searcher = new($"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {process.Id}");
            using ManagementObjectCollection objects = searcher.Get();
            var cmd = objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString() ?? string.Empty;

            return Regex.Matches(cmd, "\"([-\\w]+)(=?([-\\w]+))?\"")
                .ToDictionary(o => o.Groups[1].Value, o => o.Groups.Count == 4 ? o.Groups[3].Value : string.Empty);
        }
    }
}

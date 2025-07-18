using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftReady.Assist
{
    public abstract class Runnable<T> : IRunnable where T : IRunnable
    {
        private static readonly object uniqueLock = new();

        private static void Print(string value)
        {
            Console.WriteLine($"[Runnable] {value}");
        }

        private void LockRun()
        {
            if (Monitor.TryEnter(uniqueLock))
            {
                Run();
                Monitor.Exit(uniqueLock);
            } 
        }

        public abstract void Run();

        public Task Start(bool withLock = false)
        {
            return withLock ? Task.Run(LockRun) : Task.Run(Run);
        }
    }
}

using LOLUtil.Assist.LOL.LCU;
using LOLUtil.Assist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLUtil.Core.Tasks
{
    public class TestLockTask : Runnable<AcceptMMTask>
    {
        private readonly LCUAccess lcu = Module<LCUAccess>.Instance;
        public override void Run()
        {
            Console.WriteLine("Lock task");
            Task.Delay(1000).Wait();
        }
    }
}

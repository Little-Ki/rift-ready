using LOLUtil.Assist;
using LOLUtil.Assist.LOL.LCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLUtil.Core.Tasks
{
    public class BanChampTask : Runnable<BanChampTask>
    {
        private readonly LCUAccess lcu = Module<LCUAccess>.Value;
        private static Config Config { get => Module<Config>.Value; }

        public override void Run()
        {

        }
    }
}

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
        private readonly LCUAccess lcu = Module<LCUAccess>.Instance;

        private readonly Config config = Module<Config>.Instance;

        public override void Run()
        {

        }
    }
}

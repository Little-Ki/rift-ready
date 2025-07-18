using RiftReady.Assist;
using RiftReady.Assist.LOL.LCU;

namespace RiftReady.Core.Tasks
{
    internal class PlayAgainTask : Runnable<PlayAgainTask>
    {
        private readonly LCUAccess lcu = Module<LCUAccess>.Value;
        public override void Run()
        {

        }
    }
}

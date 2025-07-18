using RiftReady.Assist;
using RiftReady.Assist.LOL.LCU;

namespace RiftReady.Core.Tasks
{
    public class AcceptMMTask : Runnable<AcceptMMTask>
    {
        private readonly LCUAccess lcu = Module<LCUAccess>.Value;
        public override void Run()
        {
            lcu.Send("POST", "lol-matchmaking/v1/ready-check/accept").Wait();
            Task.Delay(1000).Wait();
        }
    }
}

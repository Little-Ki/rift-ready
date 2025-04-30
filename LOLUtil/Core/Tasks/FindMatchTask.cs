using LOLUtil.Assist;
using LOLUtil.Assist.LOL.LCU;

namespace LOLUtil.Core.Tasks
{
    public class FindMatchTask : Runnable<FindMatchTask>
    {
        private readonly LCUAccess lcu = Module<LCUAccess>.Instance;

        public override void Run()
        {
            //var summoner = client.Summoner.GetCurrent();

            //if (summoner == null)
            //{
            //    return;
            //}

            //var summonerId = summoner.SummonerId;

            //var members = client.Lobby.GetMembers();

            //foreach(var it in members ?? [])
            //{
            //    if (it.IsLeader && it.SummonerID == summonerId)
            //    {
            //        client.Lobby.PostMatchmarkingSearch();
            //        break;
            //    }
            //}
        }
    }
}

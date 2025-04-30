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

        public List<int> BanIds { get; set; } = [];

        public override void Run()
        {
            //var gameStatus = client.Gameflow.GetPhase();

            //if (gameStatus == null || gameStatus != "ChampSelect")
            //{
            //    return;
            //}

            //var session = client.ChampSelect.GetSession();

            //if (session == null)
            //{
            //    return;
            //}

            //var currentBans = session.Bans.MyTeamBans.Concat(
            //    session.Bans.TheirTeamBans
            //).ToList();

            //if (session.BenchEnabled)
            //{
            //    return;
            //}

            //var summoner = client.Summoner.GetCurrent();
            //var summonerId = summoner?.SummonerId ?? 0;
            //var team = session.MyTeam;
            //var actions = session.Actions;

            //if (summoner == null)
            //{
            //    return;
            //}

            //foreach(var it in team)
            //{
            //    if (it.SummonerID != summonerId)
            //    {
            //        continue;
            //    }


            //}


        }
    }
}

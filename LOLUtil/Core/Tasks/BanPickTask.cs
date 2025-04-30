using LOLUtil.Assist;
using LOLUtil.Assist.LOL.LCU;
using LOLUtil.Assist.LOL.LCU.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LOLUtil.Core.Tasks
{
    public class BanPickTask : Runnable<BanPickTask>
    {
        private readonly LCUAccess lcu = Module<LCUAccess>.Value;

        private static Config Config { get => Module<Config>.Value; }

        public override void Run()
        {
            bool process()
            {
                var enableBan = Config.AutoBan.Enable;
                var enablePick = Config.AutoPick.Enable;

                if (!enableBan && !enablePick)
                {
                    return false;
                }

                var summonerReq = lcu.Send("GET", "lol-summoner/v1/current-summoner").Result;

                if (!summonerReq.Success)
                {
                    return false;
                }

                var summonerId = summonerReq.Json.Node("summonerId")!.GetValue<long>();

                var sessionReq = lcu.Send("GET", "lol-champ-select/v1/session").Result;

                if (!sessionReq.Success)
                {
                    return false;
                }

                var session = sessionReq.Json.Root.Deserialize<LOL_ChampSelectSession>()!;

                if (!session.Timer.Phase.Equals("BAN_PICK"))
                {
                    return false;
                }

                var ownCellId = session.MyTeam.Find(x => x.SummonerId == summonerId)!.CellId;

                var alreayBans = session.Bans.MyTeamBans.Union(session.Bans.TheirTeamBans);

                LOL_Action? action = null;

                foreach (var i in session.Actions)
                {
                    action = i.Find(x => x.ActorCellId == ownCellId && x.IsInProgress && !x.Completed);
                    if (action != null) break;
                }

                if (action == null)
                {
                    return false;
                }

                if (action.Type.Equals("ban") && enableBan)
                {
                    var recommendBans = Config.AutoBan.ChampionIds;
                    if (recommendBans.Any(x => !alreayBans.Contains(x)))
                    {
                        var confirmBan = recommendBans.First(x => !alreayBans.Contains(x));

                        action.Completed = true;
                        action.ChampionId = confirmBan;

                        lcu.Send("PATCH", $"lol-champ-select/v1/session/actions/{action.Id}", JsonContent.Create(action)).Wait();
                    }
                }

                if (action.Type.Equals("pick") && enablePick)
                {
                    var recommendPicks = Config.AutoPick.ChampionIds;
                    var pickableReq = lcu.Send("GET", "lol-champ-select/v1/pickable-champion-ids").Result;

                    if (!pickableReq.Success)
                    {
                        return false;
                    }

                    var pickableIds = pickableReq.Json.Root!.AsArray().Deserialize<List<int>>() ?? [];

                    if (recommendPicks.Any(x => !alreayBans.Contains(x) && pickableIds.Contains(x)))
                    {
                        var confirmPick = recommendPicks.First(x => !alreayBans.Contains(x) && pickableIds.Contains(x));

                        action.Completed = true;
                        action.ChampionId = confirmPick;

                        lcu.Send("PATCH", $"lol-champ-select/v1/session/actions/{action.Id}", JsonContent.Create(action)).Wait();
                    }
                }

                return true;
            }

            try
            {
                if (process())
                {
                    Task.Delay(15).Wait();
                }
                else
                {
                    Task.Delay(1000).Wait();
                }
            }
            catch
            {
                Task.Delay(1000).Wait();
            }
        }
    }
}

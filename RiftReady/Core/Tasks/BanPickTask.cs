using RiftReady.Assist;
using RiftReady.Assist.Http;
using RiftReady.Assist.LOL.LCU;
using RiftReady.Assist.LOL.LCU.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RiftReady.Core.Tasks
{
    public class BanPickTask : Runnable<BanPickTask>
    {
        private readonly LCUAccess lcu = Module<LCUAccess>.Value;

        private static Config Config { get => Module<Config>.Value; }

        public override void Run()
        {
            bool process()
            {
                HttpResult? result;
                var enableBan = Config.AutoBan.Enable;
                var enablePick = Config.AutoPick.Enable;

                if (!enableBan && !enablePick)
                {
                    return false;
                }

                result = lcu.Send("GET", "lol-summoner/v1/current-summoner").Result;
                var summonerId = result.Json.Value<long>("summonerId");

                result = lcu.Send("GET", "lol-champ-select/v1/session").Result;

                var session = result.Json.Object<LOL_ChampSelectSession>()!;
                var ownCellId = session.MyTeam.Find(x => x.SummonerId == summonerId)!.CellId;
                var alreayBans = session.Bans.MyTeamBans.Union(session.Bans.TheirTeamBans);

                LOL_Action? action = session
                    .Actions
                    .Where(x => x.Any(x => x.ActorCellId == ownCellId && x.IsInProgress))
                    .Select(x => x.First(x => x.ActorCellId == ownCellId && x.IsInProgress))
                    .FirstOrDefault();

                result = lcu.Send("GET", "lol-champ-select/v1/pickable-champion-ids").Result;
                var pickableIds = result.Json.Array<List<int>>() ?? [];
                var benchChampions = session.BenchChampions;

                if (action != null)
                {
                    if (action.Type.Equals("ban") && enableBan)
                    {
                        var recommendBans = Config.AutoBan.ChampionIds;
                        var confirmBan = recommendBans.FirstOrDefault(x => !alreayBans.Contains(x));
                        if (confirmBan != 0)
                        {
                            action.Completed = true;
                            action.ChampionId = confirmBan;

                            lcu.Send("PATCH", $"lol-champ-select/v1/session/actions/{action.Id}", JsonContent.Create(action)).Wait();
                        }
                    }

                    if (action.Type.Equals("pick") && enablePick)
                    {
                        var recommendPicks = Config.AutoPick.ChampionIds;
                        var confirmPick = recommendPicks.FirstOrDefault(x => !alreayBans.Contains(x) && pickableIds.Contains(x));

                        if (confirmPick != 0)
                        {
                            action.Completed = true;
                            action.ChampionId = confirmPick;

                            lcu.Send("PATCH", $"lol-champ-select/v1/session/actions/{action.Id}", JsonContent.Create(action)).Wait();
                        }
                    }
                }
                else
                {
                    if (benchChampions.Count > 0 && enablePick)
                    {
                        result = lcu.Send("GET", "lol-champ-select/v1/current-champion").Result;
                        var recommendPicks = Config.AutoPick.ChampionIds;

                        var switchFrom = result.Json.Value<int>();
                        var switchTo = recommendPicks
                            .FirstOrDefault(
                            x => pickableIds.Contains(x) && !alreayBans.Contains(x) && benchChampions.Any(y => y.ChampionId == x)
                            );

                        if (switchTo != 0)
                        {
                            var indexFrom = recommendPicks.IndexOf(switchFrom);
                            var indexTo = recommendPicks.IndexOf(switchTo);
                            if (indexFrom == -1 || indexFrom > indexTo)
                            {
                                lcu.Send("POST", $"lol-champ-select/v1/session/bench/swap/{switchTo}").Wait();
                            }
                        }
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

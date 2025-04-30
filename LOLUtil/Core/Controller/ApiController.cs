using LOLUtil.Assist;
using LOLUtil.Assist.LOL;
using LOLUtil.Assist.LOL.LCU;
using LOLUtil.Assist.LOL.Riot;
using LOLUtil.Assist.Server;
using LOLUtil.Utils;
using System.Text.Json.Serialization;

namespace LOLUtil.Core.Controller
{
    public class ApiController
    {
        private record GameStatus
        {
            [property: JsonPropertyName("isOpen")]
            public required bool IsOpen { get; set; } = false;

            [property: JsonPropertyName("lcuPort")]
            public required string LCUPort { get; set; } = string.Empty;

            [property: JsonPropertyName("lcuToken")]
            public required string LCUToken { get; set; } = string.Empty;
        }

        public static void GetConfig(ServerRecv _, ServerSend send)
        {
            var config = Module<Config>.Instance;

            send.Json(new ResponseObject<Config>() { Data = config });
        }

        public static void PostConfig(ServerRecv recv, ServerSend send)
        {
            try
            {
                var config = recv.Json<Config>();
                if (config != null)
                {
                    config.AutoBan.ChampionIds = config.AutoBan.ChampionIds.Distinct().ToList();
                    config.AutoPick.ChampionIds = config.AutoPick.ChampionIds.Distinct().ToList();
                    Module<Config>.Instance.AutoBan = config.AutoBan;
                    Module<Config>.Instance.AutoPick = config.AutoPick;
                    Module<Config>.Instance.Feature = config.Feature;
                    Misc.WriteJson(config, "config.json");
                }

                send.Json(new ResponseObject<Config>() { Data = Module<Config>.Instance });
            }
            catch
            {
                send.Json(new Response() { Code = 500, Message = "Internal Error" });
            }
        }

        public static void GetStatus(ServerRecv _, ServerSend send)
        {
            var process = ProcessFinder.GetProcess("LeagueClientUx");
            var lcu = Module<LCUAccess>.Instance;

            send.Json(new ResponseObject<GameStatus>()
            {
                Data = new()
                {
                    IsOpen = process != null,
                    LCUPort = lcu.Port,
                    LCUToken = lcu.Token
                }
            });
        }

        public static void GetHeros(ServerRecv recv, ServerSend send)
        {
            var chamnpions = Module<Champions>.Instance;
            var keyword = recv.Param("keyword");
            var id = recv.Param("id");

            var list = chamnpions.List
                .Where(x => keyword == null || keyword == string.Empty || x.Keywords.Any(x => x.StartsWith(keyword)))
                .Where(x => id == null || id == string.Empty || x.HeroID == id)
                .ToList();

            send.Json(new ResponseObject<List<LOL_Hero>>() { Data = list });
        }
    }
}

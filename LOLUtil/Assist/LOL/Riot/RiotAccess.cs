using LOLUtil.Assist.Http;
using System.Text.Json;

namespace LOLUtil.Assist.LOL.Riot
{
    public static class RiotAccess
    {
        public static LOL_HeroList? GetHeroList()
        {
            var result = new HttpAccess().Send("GET", "https://game.gtimg.cn/images/lol/act/img/js/heroList/hero_list.js").Result;

            if (result == null)
            {
                return null;
            }

            return result.Json.Node().Deserialize<LOL_HeroList>();
        }
    }
}

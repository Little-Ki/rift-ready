using LOLUtil.Assist.LOL.Riot;

namespace LOLUtil.Assist.LOL
{
    public class Champions
    {
        public List<LOL_Hero> List { get; private set; } = [];

        public bool Update()
        {
            var heros = RiotAccess.GetHeroList();

            if (heros == null)
            {
                return false;
            }

            List = heros.Hero;

            return true;
        }

        public LOL_Hero? Find(string any)
        {
            return List.Where(x => x.Keywords.Contains(any) || x.HeroID == any).First();
        }
    }
}

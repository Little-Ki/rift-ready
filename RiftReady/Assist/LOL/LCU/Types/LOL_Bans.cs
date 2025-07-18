using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LOLUtil.Assist.LOL.LCU.Types
{
    public record LOL_Bans
    {
        [JsonPropertyName("myTeamBans")]
        public required List<int> MyTeamBans { get; set; }

        [JsonPropertyName("numBans")]
        public int NumBans { get; set; }

        [JsonPropertyName("theirTeamBans")]
        public required List<int> TheirTeamBans { get; set; }
    }
}

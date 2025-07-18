using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiftReady.Assist.LOL.LCU.Types
{
    public record LOL_Summoner
    {
        [JsonPropertyName("accountId")]
        public long AccountId;

        [JsonPropertyName("displayName")]
        public required string DisplayName;

        [JsonPropertyName("gameName")]
        public required string GameName;

        [JsonPropertyName("internalName")]
        public required string InternalName;

        [JsonPropertyName("nameChangeFlag")]
        public bool NameChangeFlag;

        [JsonPropertyName("percentCompleteForNextLevel")]
        public int PercentCompleteForNextLevel;

        [JsonPropertyName("privacy")]
        public required string Privacy;

        [JsonPropertyName("profileIconId")]
        public int ProfileIconId;

        [JsonPropertyName("puuid")]
        public required string Puuid;

        [JsonPropertyName("rerollPoints")]
        public required LOL_RerollPoints RerollPoints;

        [JsonPropertyName("summonerId")]
        public long SummonerId;

        [JsonPropertyName("summonerLevel")]
        public int SummonerLevel;

        [JsonPropertyName("tagLine")]
        public required string TagLine;

        [JsonPropertyName("unnamed")]
        public bool Unnamed;

        [JsonPropertyName("xpSinceLastLevel")]
        public int XpSinceLastLevel;

        [JsonPropertyName("xpUntilNextLevel")]
        public int XpUntilNextLevel;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LOLUtil.Assist.LOL.LCU.Types
{
    public record LOL_Team
    {
        [JsonPropertyName("assignedPosition")]
        public required string AssignedPosition { get; set; }

        [JsonPropertyName("cellId")]
        public int CellId { get; set; }

        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }

        [JsonPropertyName("championPickIntent")]
        public int ChampionPickIntent { get; set; }

        [JsonPropertyName("gameName")]
        public required string GameName { get; set; }

        [JsonPropertyName("isHumanoid")]
        public bool? IsHumanoid { get; set; }

        [JsonPropertyName("nameVisibilityType")]
        public required string NameVisibilityType { get; set; }

        [JsonPropertyName("obfuscatedPuuid")]
        public required string ObfuscatedPuuid { get; set; }

        [JsonPropertyName("obfuscatedSummonerId")]
        public required long ObfuscatedSummonerId { get; set; }

        [JsonPropertyName("puuid")]
        public required string Puuid { get; set; }

        [JsonPropertyName("selectedSkinId")]
        public int SelectedSkinId { get; set; }

        [JsonPropertyName("spell1Id")]
        public int Spell1Id { get; set; }

        [JsonPropertyName("spell2Id")]
        public int Spell2Id { get; set; }

        [JsonPropertyName("summonerId")]
        public long SummonerId { get; set; }

        [JsonPropertyName("tagLine")]
        public required string TagLine { get; set; }

        [JsonPropertyName("team")]
        public int Team { get; set; }
    }
}

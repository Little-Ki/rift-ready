using System.Text.Json.Serialization;

namespace LOLUtil.Assist.LOL.LCU.Types
{
    public record LOL_ChampSelectSession
    {
        [JsonPropertyName("actions")]
        public List<List<LOL_Action>> Actions { get; set; } = [];

        [JsonPropertyName("allowBattleBoost")]
        public bool AllowBattleBoost { get; set; }

        [JsonPropertyName("allowDuplicatePicks")]
        public bool AllowDuplicatePicks { get; set; }

        [JsonPropertyName("allowLockedEvents")]
        public bool AllowLockedEvents { get; set; }

        [JsonPropertyName("allowRerolling")]
        public bool AllowRerolling { get; set; }

        [JsonPropertyName("allowSkinSelection")]
        public bool AllowSkinSelection { get; set; }

        [JsonPropertyName("allowSubsetChampionPicks")]
        public bool AllowSubsetChampionPicks { get; set; }

        [JsonPropertyName("bans")]
        public required LOL_Bans Bans { get; set; }

        [JsonPropertyName("benchChampions")]
        public List<LOL_BenchChampion> BenchChampions { get; set; } = [];

        [JsonPropertyName("benchEnabled")]
        public bool BenchEnabled { get; set; }

        [JsonPropertyName("boostableSkinCount")]
        public int BoostableSkinCount { get; set; }

        [JsonPropertyName("chatDetails")]
        public required LOL_ChatDetails ChatDetails { get; set; }

        [JsonPropertyName("counter")]
        public int Counter { get; set; }

        [JsonPropertyName("gameId")]
        public long GameId { get; set; }

        [JsonPropertyName("hasSimultaneousBans")]
        public bool HasSimultaneousBans { get; set; }

        [JsonPropertyName("hasSimultaneousPicks")]
        public bool HasSimultaneousPicks { get; set; }

        [JsonPropertyName("isCustomGame")]
        public bool IsCustomGame { get; set; }

        [JsonPropertyName("isLegacyChampSelect")]
        public bool IsLegacyChampSelect { get; set; }

        [JsonPropertyName("isSpectating")]
        public bool IsSpectating { get; set; }

        [JsonPropertyName("localPlayerCellId")]
        public int LocalPlayerCellId { get; set; }

        [JsonPropertyName("lockedEventIndex")]
        public int LockedEventIndex { get; set; }

        [JsonPropertyName("myTeam")]
        public List<LOL_Team> MyTeam { get; set; } = [];

        [JsonPropertyName("pickOrderSwaps")]
        public List<LOL_Swap> PickOrderSwaps { get; set; } = [];

        [JsonPropertyName("positionSwaps")]
        public List<LOL_Swap> PositionSwaps { get; set; } = [];

        [JsonPropertyName("rerollsRemaining")]
        public int? RerollsRemaining { get; set; }

        [JsonPropertyName("showQuitButton")]
        public bool? ShowQuitButton { get; set; }

        [JsonPropertyName("skipChampionSelect")]
        public bool? SkipChampionSelect { get; set; }

        [JsonPropertyName("theirTeam")]
        public List<LOL_Team> TheirTeam { get; set; } = [];

        [JsonPropertyName("timer")]
        public required LOL_Timer Timer { get; set; }

        [JsonPropertyName("trades")]
        public List<LOL_Trade> Trades { get; set; } = [];
    }
}

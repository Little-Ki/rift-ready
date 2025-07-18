using System.Text.Json.Serialization;

namespace RiftReady.Assist.LOL.LCU.Types
{
    public record LOL_MemberData
    {
        [JsonPropertyName("cherry_level")]
        public required string CherryLevel;

        [JsonPropertyName("cherry_progression_total")]
        public required string CherryProgressionTotal;
    }
    public record LOL_Member
    {
        [JsonPropertyName("allowedChangeActivity")]
        public bool AllowedChangeActivity;

        [JsonPropertyName("allowedInviteOthers")]
        public bool AllowedInviteOthers;

        [JsonPropertyName("allowedKickOthers")]
        public bool AllowedKickOthers;

        [JsonPropertyName("allowedStartActivity")]
        public bool AllowedStartActivity;

        [JsonPropertyName("allowedToggleInvite")]
        public bool AllowedToggleInvite;

        [JsonPropertyName("autoFillEligible")]
        public bool AutoFillEligible;

        [JsonPropertyName("autoFillProtectedForPromos")]
        public bool AutoFillProtectedForPromos;

        [JsonPropertyName("autoFillProtectedForRemedy")]
        public bool AutoFillProtectedForRemedy;

        [JsonPropertyName("autoFillProtectedForSoloing")]
        public bool AutoFillProtectedForSoloing;

        [JsonPropertyName("autoFillProtectedForStreaking")]
        public bool AutoFillProtectedForStreaking;

        [JsonPropertyName("botChampionId")]
        public int BotChampionId;

        [JsonPropertyName("botDifficulty")]
        public required string BotDifficulty;

        [JsonPropertyName("botId")]
        public required string BotId;

        [JsonPropertyName("botPosition")]
        public required string BotPosition;

        [JsonPropertyName("botUuid")]
        public required string BotUuid;

        [JsonPropertyName("firstPositionPreference")]
        public required string FirstPositionPreference;

        [JsonPropertyName("intraSubteamPosition")]
        public int IntraSubteamPosition;

        [JsonPropertyName("isBot")]
        public bool IsBot;

        [JsonPropertyName("isLeader")]
        public bool IsLeader;

        [JsonPropertyName("isSpectator")]
        public bool IsSpectator;

        [JsonPropertyName("memberData")]
        public required LOL_MemberData MemberData;

        [JsonPropertyName("playerSlots")]
        public List<object> PlayerSlots = [];

        [JsonPropertyName("puuid")]
        public required string Puuid;

        [JsonPropertyName("ready")]
        public bool Ready;

        [JsonPropertyName("secondPositionPreference")]
        public required string SecondPositionPreference;

        [JsonPropertyName("showGhostedBanner")]
        public bool ShowGhostedBanner;

        [JsonPropertyName("strawberryMapId")]
        public object? StrawberryMapId;

        [JsonPropertyName("subteamIndex")]
        public int SubteamIndex;

        [JsonPropertyName("summonerIconId")]
        public int SummonerIconId;

        [JsonPropertyName("summonerId")]
        public long SummonerId;

        [JsonPropertyName("summonerInternalName")]
        public required string SummonerInternalName;

        [JsonPropertyName("summonerLevel")]
        public int SummonerLevel;

        [JsonPropertyName("summonerName")]
        public required string SummonerName;

        [JsonPropertyName("teamId")]
        public int TeamId;
    }


}

using System.Text.Json.Serialization;

namespace RiftReady.Assist.LOL.LCU.Types
{
    public record LOL_LOL
    {
        [JsonPropertyName("bannerIdSelected")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BannerIdSelected { get; set; }

        [JsonPropertyName("challengeCrystalLevel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ChallengeCrystalLevel { get; set; }

        [JsonPropertyName("challengePoints")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ChallengePoints { get; set; }

        [JsonPropertyName("challengeTokensSelected")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ChallengeTokensSelected { get; set; }

        [JsonPropertyName("championId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ChampionId { get; set; }

        [JsonPropertyName("companionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CompanionId { get; set; }

        [JsonPropertyName("damageSkinId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DamageSkinId { get; set; }

        [JsonPropertyName("gameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? GameId { get; set; }

        [JsonPropertyName("gameMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? GameMode { get; set; }

        [JsonPropertyName("gameQueueType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? GameQueueType { get; set; }

        [JsonPropertyName("gameStatus")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? GameStatus { get; set; }

        [JsonPropertyName("iconOverride")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IconOverride { get; set; }

        [JsonPropertyName("isObservable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IsObservable { get; set; }

        [JsonPropertyName("legendaryMasteryScore")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LegendaryMasteryScore { get; set; }

        [JsonPropertyName("level")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Level { get; set; }

        [JsonPropertyName("mapId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MapId { get; set; }

        [JsonPropertyName("mapSkinId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MapSkinId { get; set; }

        [JsonPropertyName("playerTitleSelected")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PlayerTitleSelected { get; set; }

        [JsonPropertyName("pty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Pty { get; set; }

        [JsonPropertyName("puuid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Puuid { get; set; }

        [JsonPropertyName("queueId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? QueueId { get; set; }

        [JsonPropertyName("rankedPrevSeasonDivision")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RankedPrevSeasonDivision { get; set; }

        [JsonPropertyName("rankedPrevSeasonTier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RankedPrevSeasonTier { get; set; }

        [JsonPropertyName("regalia")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Regalia { get; set; }

        [JsonPropertyName("skinVariant")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SkinVariant { get; set; }

        [JsonPropertyName("skinname")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Skinname { get; set; }

        [JsonPropertyName("timeStamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? TimeStamp { get; set; }
    }
}

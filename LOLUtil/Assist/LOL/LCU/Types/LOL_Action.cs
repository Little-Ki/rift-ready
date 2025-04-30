using System.Text.Json.Serialization;

namespace LOLUtil.Assist.LOL.LCU.Types
{
    public record LOL_Action
    {
        [JsonPropertyName("actorCellId")]
        public int ActorCellId { get; set; }

        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }

        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("isAllyAction")]
        public bool IsAllyAction { get; set; }

        [JsonPropertyName("isInProgress")]
        public bool IsInProgress { get; set; }

        // ban / pick
        [JsonPropertyName("type")]
        public required string Type { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace LOLUtil.Assist.LOL.LCU.Types
{
    public record LOL_Action
    {
        [JsonPropertyName("actorCellId")]
        public int ActorCellId;

        [JsonPropertyName("championId")]
        public int ChampionId;

        [JsonPropertyName("completed")]
        public bool Completed;

        [JsonPropertyName("id")]
        public int Id;

        [JsonPropertyName("isAllyAction")]
        public bool IsAllyAction;

        [JsonPropertyName("isInProgress")]
        public bool IsInProgress;

        // ban / pick
        [JsonPropertyName("type")]
        public required string Type;
    }
}

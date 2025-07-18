using System.Text.Json.Serialization;

namespace RiftReady.Assist.LOL.LCU.Types
{
    public record LOL_GameConfig
    {
        [JsonPropertyName("allowablePremadeSizes")]
        public List<int> AllowablePremadeSizes = [];

        [JsonPropertyName("customLobbyName")]
        public required string CustomLobbyName;

        [JsonPropertyName("customMutatorName")]
        public required string CustomMutatorName;

        [JsonPropertyName("customRewardsDisabledReasons")]
        public List<object> CustomRewardsDisabledReasons = [];

        [JsonPropertyName("customSpectatorPolicy")]
        public required string CustomSpectatorPolicy;

        [JsonPropertyName("customSpectators")]
        public List<object> CustomSpectators = [];

        [JsonPropertyName("customTeam100")]
        public List<object> CustomTeam100 = [];

        [JsonPropertyName("customTeam200")]
        public List<object> CustomTeam200 = [];

        [JsonPropertyName("gameMode")]
        public required string GameMode;

        [JsonPropertyName("isCustom")]
        public bool IsCustom;

        [JsonPropertyName("isLobbyFull")]
        public bool IsLobbyFull;

        [JsonPropertyName("isTeamBuilderManaged")]
        public bool IsTeamBuilderManaged;

        [JsonPropertyName("mapId")]
        public int MapId;

        [JsonPropertyName("maxHumanPlayers")]
        public int MaxHumanPlayers;

        [JsonPropertyName("maxLobbySize")]
        public int MaxLobbySize;

        [JsonPropertyName("maxTeamSize")]
        public int MaxTeamSize;

        [JsonPropertyName("pickType")]
        public required string PickType;

        [JsonPropertyName("premadeSizeAllowed")]
        public bool PremadeSizeAllowed;

        [JsonPropertyName("queueId")]
        public int QueueId;

        [JsonPropertyName("shouldForceScarcePositionSelection")]
        public bool ShouldForceScarcePositionSelection;

        [JsonPropertyName("showPositionSelector")]
        public bool ShowPositionSelector;

        [JsonPropertyName("showQuickPlaySlotSelection")]
        public bool ShowQuickPlaySlotSelection;
    }
}

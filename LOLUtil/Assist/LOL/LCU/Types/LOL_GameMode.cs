using System.Text.Json.Serialization;

namespace LOLUtil.Assist.LOL.LCU.Types
{
    public class LOL_GameCustomization
    {
        [JsonPropertyName("popularChampions")]
        public required string PopularChampions;
    }

    public record LOL_GameMode
    {
        [JsonPropertyName("allowSpectators")]
        public object? AllowSpectators;

        [JsonPropertyName("customGameMode")]
        public object? CustomGameMode;

        [JsonPropertyName("gameCustomization")]
        public required LOL_GameCustomization GameCustomization;

        [JsonPropertyName("gameType")]
        public required string GameType;

        [JsonPropertyName("gameTypeConfigId")]
        public required int GameTypeConfigId;

        [JsonPropertyName("lobbyName")]
        public object? LobbyName;

        [JsonPropertyName("lobbyPassword")]
        public object? LobbyPassword;

        [JsonPropertyName("mapId")]
        public object? MapId;

        [JsonPropertyName("maxPartySize")]
        public required int MaxPartySize;

        [JsonPropertyName("maxTeamSize")]
        public required int MaxTeamSize;

        [JsonPropertyName("queueId")]
        public required int QueueId;
    }


}

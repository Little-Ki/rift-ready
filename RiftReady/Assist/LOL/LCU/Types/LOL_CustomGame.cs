using System.Text.Json.Serialization;

namespace LOLUtil.Assist.LOL.LCU.Types
{
    public record LOL_CustomGame
    {
        [JsonPropertyName("filledPlayerSlots")]
        public required int FilledPlayerSlots { get; set; }

        [JsonPropertyName("filledSpectatorSlots")]
        public required int FilledSpectatorSlots { get; set; }

        [JsonPropertyName("gameType")]
        public required string? GameType { get; set; }

        [JsonPropertyName("hasPassword")]
        public required bool HasPassword { get; set; }

        [JsonPropertyName("id")]
        public required long Id { get; set; }

        [JsonPropertyName("lobbyName")]
        public required string LobbyName { get; set; }

        [JsonPropertyName("mapId")]
        public required int MapId { get; set; }

        [JsonPropertyName("maxPlayerSlots")]
        public required int MaxPlayerSlots { get; set; }

        [JsonPropertyName("maxSpectatorSlots")]
        public required int MaxSpectatorSlots { get; set; }

        [JsonPropertyName("ownerDisplayName")]
        public required string OwnerDisplayName { get; set; }

        [JsonPropertyName("partyId")]
        public required string PartyId { get; set; }

        [JsonPropertyName("passbackUrl")]
        public required string PassbackUrl { get; set; }

        [JsonPropertyName("spectatorPolicy")]
        public required string SpectatorPolicy { get; set; }
    }
}

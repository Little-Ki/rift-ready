using System.Text.Json.Serialization;

namespace RiftReady.Assist.LOL.LCU.Types
{
    public record LOL_MucJwtDto
    {
        [JsonPropertyName("channelClaim")]
        public required string ChannelClaim;

        [JsonPropertyName("domain")]
        public required string Domain;

        [JsonPropertyName("jwt")]
        public required string Jwt;

        [JsonPropertyName("targetRegion")]
        public required string TargetRegion;
    }
}

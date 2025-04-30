using System.Text.Json.Serialization;

namespace LOLUtil.Assist.LOL.LCU.Types
{
    public record LOL_Invitation
    {
        [JsonPropertyName("invitationId")]
        public required string InvitationId;

        [JsonPropertyName("invitationType")]
        public required string InvitationType;

        [JsonPropertyName("state")]
        public required string State;

        [JsonPropertyName("timestamp")]
        public required string Timestamp;

        [JsonPropertyName("toSummonerId")]
        public long ToSummonerId;

        [JsonPropertyName("toSummonerName")]
        public required string ToSummonerName;
    }
}

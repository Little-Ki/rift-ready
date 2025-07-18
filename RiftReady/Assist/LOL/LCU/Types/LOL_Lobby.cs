using System.Text.Json.Serialization;

namespace RiftReady.Assist.LOL.LCU.Types
{
    public class LOL_Lobby
    {
        [JsonPropertyName("canStartActivity")]
        public bool CanStartActivity;

        [JsonPropertyName("gameConfig")]
        public required LOL_GameConfig GameConfig;

        [JsonPropertyName("invitations")]
        public required List<LOL_Invitation> Invitations = [];

        [JsonPropertyName("localMember")]
        public required LOL_Member LocalMember;

        [JsonPropertyName("members")]
        public List<LOL_Member> Members = [];

        [JsonPropertyName("mucJwtDto")]
        public required LOL_MucJwtDto MucJwtDto;

        [JsonPropertyName("multiUserChatId")]
        public required string MultiUserChatId;

        [JsonPropertyName("multiUserChatPassword")]
        public required string MultiUserChatPassword;

        [JsonPropertyName("partyId")]
        public required string PartyId;

        [JsonPropertyName("partyType")]
        public required string PartyType;

        [JsonPropertyName("popularChampions")]
        public List<object> PopularChampions = [];

        [JsonPropertyName("restrictions")]
        public List<object> Restrictions = [];

        [JsonPropertyName("scarcePositions")]
        public List<object> ScarcePositions = [];

        [JsonPropertyName("warnings")]
        public List<object> Warnings = [];
    }


}

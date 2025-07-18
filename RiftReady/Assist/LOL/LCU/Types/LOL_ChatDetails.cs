using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiftReady.Assist.LOL.LCU.Types
{
    public record LOL_ChatDetails
    {
        [JsonPropertyName("mucJwtDto")]
        public required LOL_MucJwtDto MucJwtDto { get; set; }

        [JsonPropertyName("multiUserChatId")]
        public required string MultiUserChatId { get; set; }

        [JsonPropertyName("multiUserChatPassword")]
        public required string MultiUserChatPassword { get; set; }
    }
}

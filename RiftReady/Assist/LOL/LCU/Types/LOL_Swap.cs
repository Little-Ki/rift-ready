using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiftReady.Assist.LOL.LCU.Types
{
    public record LOL_Swap
    {
        [JsonPropertyName("cellId")]
        public int CellId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("state")]
        public required string State { get; set; }
    }
}

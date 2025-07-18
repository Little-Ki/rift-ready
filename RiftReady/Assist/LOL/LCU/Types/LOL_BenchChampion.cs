using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiftReady.Assist.LOL.LCU.Types
{
    public record LOL_BenchChampion
    {
        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }


        [JsonPropertyName("isPriority")]
        public bool IsPriority { get; set; }
    }
}

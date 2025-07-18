using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiftReady.Core
{
    public record ConfigAutoSelect
    {
        [JsonPropertyName("enable")]
        public bool Enable { get; set; } = false;

        [JsonPropertyName("championIds")]
        public List<int> ChampionIds { get; set; } = [];
    }

    public record ConfigFeature
    {
        [JsonPropertyName("autoAcceptMM")]
        public bool AutoAcceptMM { get; set; } = false;
    }

    public record  Config
    {
        [JsonPropertyName("autoBan")]
        public ConfigAutoSelect AutoBan { get; set; } = new();

        [JsonPropertyName("autoPick")]
        public ConfigAutoSelect AutoPick { get; set; } = new();

        [JsonPropertyName("feature")]
        public ConfigFeature Feature { get; set; } = new();
    }
}

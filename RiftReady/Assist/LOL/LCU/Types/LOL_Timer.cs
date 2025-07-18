using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LOLUtil.Assist.LOL.LCU.Types
{
    public record LOL_Timer
    {
        [JsonPropertyName("adjustedTimeLeftInPhase")]
        public int AdjustedTimeLeftInPhase { get; set; }

        [JsonPropertyName("internalNowInEpochMs")]
        public long InternalNowInEpochMs { get; set; }

        [JsonPropertyName("isInfinite")]
        public bool IsInfinite { get; set; }

        [JsonPropertyName("phase")]
        public required string Phase { get; set; }

        [JsonPropertyName("totalTimeInPhase")]
        public int TotalTimeInPhase { get; set; }
    }
}

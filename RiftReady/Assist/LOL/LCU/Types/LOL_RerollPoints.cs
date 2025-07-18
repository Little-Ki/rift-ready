using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RiftReady.Assist.LOL.LCU.Types
{
    public record LOL_RerollPoints
    {
        [JsonPropertyName("currentPoints")]
        public int CurrentPoints;

        [JsonPropertyName("maxRolls")]
        public int MaxRolls;

        [JsonPropertyName("numberOfRolls")]
        public int NumberOfRolls;

        [JsonPropertyName("pointsCostToRoll")]
        public int PointsCostToRoll;

        [JsonPropertyName("pointsToReroll")]
        public int PointsToReroll;
    }
}

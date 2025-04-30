using LOLUtil.Assist.Converter;
using System.Text.Json.Serialization;

namespace LOLUtil.Assist.LOL.Riot
{
    public record LOL_Hero
    {
        [property: JsonPropertyName("title")]
        public required string Title { get; set; }

        [property: JsonPropertyName("name")]
        public required string Name { get; set; }

        [property: JsonPropertyName("alias")]
        public required string Alias { get; set; }

        [property: JsonPropertyName("heroId")]
        public required string HeroID { get; set; }

        [property: JsonPropertyName("instance_id")]
        public required string InstanceID { get; set; }

        [property: JsonPropertyName("keywords")]
        [JsonConverter(typeof(JStringArrayConverter))]
        public required string[] Keywords { get; set; } = [];

        [property: JsonPropertyName("attack")]
        public required string Attack { get; set; }

        [property: JsonPropertyName("magic")]
        public required string Magic { get; set; }
    }
}

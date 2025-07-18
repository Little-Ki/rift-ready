using System.Text.Json.Serialization;

namespace LOLUtil.Assist.LOL.Riot
{
    public record LOL_HeroList
    {
        [property: JsonPropertyName("fileName")]
        public required string FileName { get; set; }

        [property: JsonPropertyName("fileTime")]
        public required string FileTime { get; set; }

        [property: JsonPropertyName("hero")]
        public required List<LOL_Hero> Hero { get; set; }

        [property: JsonPropertyName("version")]
        public required string Version { get; set; }
    }
}

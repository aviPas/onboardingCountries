using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace OnboardingCountriesDAL.Models
{
    [BsonIgnoreExtraElements]
    public class Country
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonProperty("name")]
        public string? Name { get; set; }

        [BsonElement("capital")]
        [JsonProperty("capital")]
        public string? Capital { get; set; }

        [BsonElement("region")]
        [JsonProperty("region")]
        public string? Region { get; set; }

        [BsonElement("subregion")]
        [JsonProperty("subregion")]
        public string? Subregion { get; set; }

        [BsonElement("population")]
        [JsonProperty("population")]
        public int Population { get; set; }

        [BsonElement("timezones")]
        [JsonProperty("timezones")]
        public string? Timezones { get; set; }

        [BsonElement("continents")]
        [JsonProperty("continents")]
        public string? Continents { get; set; }

        [BsonElement("flags")]
        [JsonProperty("flags")]
        public Flags? Flags { get; set; }

    }

    public class ImagesTypes
    {
        [BsonElement("png")]
        public string? Png { get; set; }

        [BsonElement("svg")]
        public string? Svg { get; set; }

    }
    public class Flags : ImagesTypes
    {

        [BsonElement("alt")]
        public string? Alt { get; set; }

    }
}

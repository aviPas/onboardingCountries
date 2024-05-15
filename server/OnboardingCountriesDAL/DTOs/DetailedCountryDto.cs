
using MongoDB.Bson.Serialization.Attributes;


namespace OnboardingCountriesDAL.DTOs
{
    [BsonIgnoreExtraElements]
    public class DetailedCountryDto : MinCountryDto
    {
        [BsonElement("timezones")]
        public string? Timezones { get; set; }

        [BsonElement("continents")] 
        public string? Continents { get; set; }
    }
}

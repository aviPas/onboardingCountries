using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using OnboardingCountriesDAL.Models;

namespace OnboardingCountriesDAL.DTOs
{
    [BsonIgnoreExtraElements]
    public class MinCountryDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string? Id { get; set; }
        [BsonElement("name")]
        public  string? Name { get; set; } 


        [BsonElement("capital")]
        public  string? Capital { get; set; }
        [BsonElement("region")]
        public  string? Region { get; set; }
        [BsonElement("subregion")]
        public  string? Subregion { get; set; }


        [BsonElement("population")]
        //[BsonRepresentation(BsonType.Int32, AllowOverflow = false)]
        public  int Population { get; set; }

        [BsonElement("flags")] 
        public  Flags? Flags { get; set; }
    }
}

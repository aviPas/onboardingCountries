using OnboardingCountriesDAL.DataAccess;
using OnboardingCountriesDAL.DTOs;
using OnboardingCountriesDAL.Models;
using log4net;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;


namespace OnboardingCountriesDAL.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {

        private readonly IMongoCollection<Country> _countries;
        private readonly ILog _Logger;

        public CountriesRepository(IMongoDbContext mongoDbContext, ILog logger )
        {
            _countries = mongoDbContext.countries;
            _Logger = logger;
        }

        public async Task<ResponseDto<IEnumerable<MinCountryDto>>> GetAll()
        {          
            _Logger.Info("DAL: Entering [GetAll]");
          
                var projection = Builders<Country>.Projection.Exclude("_id");

                List<MinCountryDto> countries = await _countries.Find(_ => true).Project<MinCountryDto>(projection).ToListAsync();

                return ResponseHandler.CreateResponse<IEnumerable<MinCountryDto>>(countries, null);
        }

        public async Task<ResponseDto<DetailedCountryDto>> GetByName(string countryName)
        {
            
            _Logger.Info("DAL: Entering [GetByName]");
           
                var projection = Builders<Country>.Projection
          .Exclude("_id");

                var filter = Builders<Country>.Filter.Eq(x => x.Name
                , countryName);

                var country = await _countries.Find(filter).Project<DetailedCountryDto>(projection).FirstOrDefaultAsync();

                if (country != null)
                {                   
                    return ResponseHandler.CreateResponse<DetailedCountryDto>( country, string.Empty);
                }
                else
                {    
                    return ResponseHandler.CreateResponse<DetailedCountryDto>(null, "Country not found");
                }
          

        }

        public async Task<ResponseDto<bool>> Update(string name, JObject country)
        {
            _Logger.Info("DAL: Entering [Update]");
    
                var filter = Builders<Country>.Filter.Eq(x => x.Name, name);
                var singleCountry = await _countries.Find(filter).FirstOrDefaultAsync();

                if (singleCountry == null)
                {
                    return ResponseHandler.CreateResponse(false, "Country not found for update.");
                }

                var updateDefinitionBuilder = new UpdateDefinitionBuilder<Country>();
                var updateDefinition = updateDefinitionBuilder.Combine(country.Properties().Select(property => updateDefinitionBuilder.Set(property.Name, BsonValue.Create(property.Value.ToObject<object>()))));

                var result = await _countries.UpdateOneAsync(filter, updateDefinition);

                return ResponseHandler.CreateResponse(true, null);           
        }


    }
}

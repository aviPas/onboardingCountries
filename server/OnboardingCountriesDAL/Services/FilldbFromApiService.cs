using MongoDB.Driver;
using Newtonsoft.Json;
using log4net;
using OnboardingCountriesDAL.Models;
using OnboardingCountriesDAL.DataAccess;

namespace OnboardingCountriesDAL.Services
{
    public class FilldbFromApiService : IFilldbFromApiService
    {
        private readonly IMongoCollection<Country> collection;
        private readonly string _apiUrlstring;
        private readonly ILog _Logger;

        public FilldbFromApiService(IMongoDbSettings settings, ILog logger)
        {
            var database = settings.Client.GetDatabase(settings.DatabaseName);
            var _collection = database.GetCollection<Country>(settings.CollectionName);
            collection = _collection;
            _apiUrlstring = settings.ApiString;
            _Logger = logger;
        }



        public async Task HandleMongoDBData()
        {
            _Logger.Info("DAL: Entering [HandleMongoDBData]");

            try
            { 
               
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_apiUrlstring);
            var data = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<List<dynamic>>(data);
            var existingData = collection != null ? await collection.Find(_ => true).ToListAsync() : [];

            if (existingData?.Count == 0 && collection!=null && apiResponse!=null)
            {
                    _Logger.Info("DAL: [HandleMongoDBData] :Starting to create collection");


                    foreach (var item in apiResponse)
                {
                    var populationData = new Country
                    {
                        Name = item.name?.common,
                        Capital = item.capital?.Count > 0 ? item.capital[0] : null,
                        Population = item?.population != null ? item.population : 0,
                        Region = item?.region,
                        Subregion = item?.subregion,
                        Timezones = item?.timezones?.Count > 0 ? item.timezones[0] : null,
                        Continents = item?.continents?.Count > 0 ? item.continents[0] : null,
                        Flags = item?.flags != null ? item.flags.ToObject<Flags>() : null

                    };

                    await collection.InsertOneAsync(populationData);
                }
                    _Logger.Info("DAL: [HandleMongoDBData] : Collection was created successfully !");
                }
                else
                {
                    _Logger.Info("DAL: [HandleMongoDBData] :collection allready exists");
                }

        }catch (Exception ex)
            {
                _Logger.Info("DAL: [HandleMongoDBData] : **ERROR** :Failed to create collection");
                return ; 
            }
    }




    }
}

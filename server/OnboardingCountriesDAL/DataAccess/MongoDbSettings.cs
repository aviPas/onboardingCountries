using MongoDB.Driver;
namespace OnboardingCountriesDAL.DataAccess
{
    public class MongoDbSettings: IMongoDbSettings
    {
        public IMongoClient Client { get; private set; }
        public string DatabaseName { get; private set; }
        public string CollectionName { get; private set; }
        public string ApiString { get; private set; }

        public MongoDbSettings(IMongoClient client, string databaseName, string collectionName, string apiString)
        {
            Client = client;
            DatabaseName = databaseName;
            CollectionName = collectionName;
            ApiString = apiString;
        }


    }

}

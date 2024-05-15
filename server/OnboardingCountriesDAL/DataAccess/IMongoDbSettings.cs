using MongoDB.Driver;


namespace OnboardingCountriesDAL.DataAccess
{
    public interface IMongoDbSettings
    {
        IMongoClient Client { get; }
        string DatabaseName { get; }
        string CollectionName { get; }
        string ApiString { get; }
    }
}

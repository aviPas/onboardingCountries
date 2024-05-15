using OnboardingCountriesDAL.Models;
using MongoDB.Driver;


namespace OnboardingCountriesDAL.DataAccess
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;

        public MongoDbContext(IMongoDbSettings settings)
        {
            _database = settings.Client.GetDatabase(settings.DatabaseName);
            _collectionName = settings.CollectionName;
        }

        public IMongoCollection<Country> countries => _database.GetCollection<Country>(_collectionName);
    }
}

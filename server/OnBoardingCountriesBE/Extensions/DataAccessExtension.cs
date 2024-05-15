using OnboardingCountriesDAL.DataAccess;
using MongoDB.Driver;

namespace OnBoardingCountriesBE.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    public static class DataAccessExtension
    {
        public static void AddMongoDBConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoclient = new MongoClient(configuration.GetConnectionString("MongoDB"));
            services.AddSingleton<IMongoClient>(mongoclient);

            string dbName = configuration.GetConnectionString("dbName") ?? "";
            string collectionName = configuration.GetConnectionString("collectionName") ?? "";
            string apiString = configuration.GetConnectionString("apiString") ?? "";

            services.AddSingleton<IMongoDbSettings>(new MongoDbSettings(mongoclient, dbName, collectionName, apiString));
            services.AddSingleton<IMongoDbContext,MongoDbContext>();
        }
    }
}

using MongoDB.Driver;
using OnboardingCountriesDAL.Models;


namespace OnboardingCountriesDAL.DataAccess
{
    public interface IMongoDbContext
    {
        IMongoCollection<Country> countries { get; }
    }
}

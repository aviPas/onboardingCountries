using OnboardingCountriesDAL.DTOs;
using Newtonsoft.Json.Linq;




namespace OnboardingCountriesDAL.Repositories
{
    public interface ICountriesRepository
    {
        Task<ResponseDto<DetailedCountryDto>> GetByName(string countryName);
        Task<ResponseDto<IEnumerable<MinCountryDto>>> GetAll();
        Task<ResponseDto<bool>> Update(string name,  JObject country);

   
    }
}

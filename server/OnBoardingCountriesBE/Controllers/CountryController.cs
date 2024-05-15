using OnboardingCountriesDAL.DTOs;
using OnboardingCountriesDAL.Repositories;
using log4net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace OnBoardingCountriesBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        
        private readonly ILog _Logger;
        private readonly ICountriesRepository _countriesRepository;
        public CountryController(ICountriesRepository countriesRepository, ILog Logger)
        {
            _countriesRepository = countriesRepository;
            _Logger = Logger;
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Get(string name)
        {
            _Logger.Info("OnBoarding: [Controller] Entering [Get(name)]");

            var countryResponse = await _countriesRepository.GetByName(name);

            if (countryResponse.Data != null)
            {
                _Logger.Info("OnBoarding: [Controller] [Get(name)] Success!");
                return Ok(new JsonResult(countryResponse.Data));
            }
            else
            {
                _Logger.Error($"OnBoarding: [Controller] [Get(name)] **ERROR** - {countryResponse.ErrorMessage}");

                if (string.IsNullOrEmpty(countryResponse.ErrorMessage))
                {
                    return NotFound();
                }
                else
                {
                    
                    return BadRequest(countryResponse.ErrorMessage);
                }
            }
        }




        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            _Logger.Info("OnBoarding: [Controller] Entering [Get()]");
            ResponseDto<IEnumerable<MinCountryDto>> countriesResponse = await _countriesRepository.GetAll();

            if (countriesResponse.Data == null)
            {
                _Logger.Error("OnBoarding: [Controller] [Get()] **ERROR** _ **NotFound**");
                return NotFound(countriesResponse.ErrorMessage);
            }

            _Logger.Info("OnBoarding: [Controller] [Get()] Success!");
            return Ok(countriesResponse.Data);


        }


        [HttpPut("{name}", Name = "UpdateVila")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCountry(string name, [FromBody] JObject country)
        {

            _Logger.Info("OnBoarding: [Controller] Entering [UpdateCountry()]");

            if (country == null)
            {
                _Logger.Error("OnBoarding: [Controller] [UpdateCountry()] **ERROR** - **BadRequest**");
                return BadRequest();
            }

            var response = await _countriesRepository.Update(name, country);

            if (!response.Data)
            {
                _Logger.Error("OnBoarding: [Controller] [UpdateCountry()] **ERROR** - **BadRequest**");
                return BadRequest(response.ErrorMessage);
            }

            _Logger.Info("OnBoarding: [Controller] [UpdateCountry()] Success!");
            return NoContent();

        }
    }
}

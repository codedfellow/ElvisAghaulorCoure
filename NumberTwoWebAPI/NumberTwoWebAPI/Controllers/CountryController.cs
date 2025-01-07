using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NumberTwoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Route("get-country-details-with-phone-number")]
        public async Task<IActionResult> GetCountryDetailsWithPhoneNumber([FromQuery]string phoneNumber)
        {
            return Ok("yet to be implemented");
        }
    }
}

using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.Current.Cities);

        }

        [HttpGet("{Id}")]
        public ActionResult<CityDto> GetCity(int id)
        {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (city is null)
                return NotFound();
            return Ok(city);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Models;
namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var _city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (_city is null)
                return NotFound();
            return Ok(_city.PointsOfInterest);
        }

        [HttpGet("{pointofinterestId}")]

        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointofInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city is null) return NotFound();

            //find point of interest
            var _pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointofInterestId);
            if (_pointOfInterest is null) return NotFound();

            return Ok(_pointOfInterest);
        }
    }
}

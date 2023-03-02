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

        [HttpGet("{pointofinterestId}", Name = "GetPointOfInterest")]

        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointofInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city is null) return NotFound();

            //find point of interest
            var _pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointofInterestId);
            if (_pointOfInterest is null) return NotFound();

            return Ok(_pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, /*This Attribute is not necessary since the It's an ApiController*/[FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            if (!ModelState.IsValid) return BadRequest();

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city is null) return NotFound();

            //Get the last Id (for demo only)
            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new { cityId = cityId, pointOfInterestId = finalPointOfInterest.Id },
                finalPointOfInterest
                );
        }
    }
}

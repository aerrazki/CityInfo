using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;

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
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, /*This Attribute is not necessary since the It's an ApiController*/ [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            //Optional, managed by APIRequired
            if (!ModelState.IsValid) return BadRequest(ModelState);

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

        [HttpPut("{pointofinterestId}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city is null) return NotFound();

            //find point of interest
            var _pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            if (_pointOfInterest is null) return NotFound();

            _pointOfInterest.Name = pointOfInterest.Name;
            _pointOfInterest.Description = pointOfInterest.Description; 

            return NoContent();
        }

        [HttpPatch("{pointofinterestId}")]
        public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId, JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument /*Patch document is the list of operations we want to execute on our point of interest*/)
        {
            //find the city
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city is null) return NotFound();

            //find the point of interest
            var _pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == pointOfInterestId);
            if (_pointOfInterest is null) return NotFound();

            var _pointOfInterestToPatch = new PointOfInterestForUpdateDto() {Name = _pointOfInterest.Name, Description = _pointOfInterest.Description };

            patchDocument.ApplyTo(_pointOfInterestToPatch,ModelState);

            /*Verifying the ModelState after the patch application
             * take note that the input model is not the PointOfInterestForUpdateDto it is the JsonPatchDocument
             * so as long as the jsonpatch doc is valid according to the RFC standards then the model is valid
             */
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //Verify the PointOfInterestForUpdateDto input validity after applying the patch document
            if (!TryValidateModel(_pointOfInterestToPatch))
                return BadRequest(ModelState);
            _pointOfInterest.Name = _pointOfInterestToPatch.Name;
            _pointOfInterest.Description = _pointOfInterestToPatch.Description;

            return NoContent();

        }
    }
}

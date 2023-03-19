using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using CityInfo.API.Services;
using CityInfo.API.Services.Interfaces;
using AutoMapper;
using CityInfo.API.Entities;
using Microsoft.AspNetCore.Authorization;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [Authorize]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMapper _mapper;
        private readonly IMailService _localMailService;
        private readonly ICityInfoRepository _cityInfoRepository;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService localMailService, ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _localMailService = localMailService ??
                throw new ArgumentNullException(nameof(localMailService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _cityInfoRepository = cityInfoRepository ??
                throw new ArgumentNullException(nameof(cityInfoRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(int cityId)
        {
            try
            {
                var cityExists = await _cityInfoRepository.CityExistsAsync(cityId);

                if (!cityExists)
                {
                    _logger.LogInformation($"The city with Id {cityId} was not found.");
                    return NotFound();
                }
                var pointsOfInterests = _cityInfoRepository.GetPointsOfInterestsForCityAsync(cityId);
                return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterests));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting point of interest of city with cityId {cityId}",
                 ex);
                //We make sure to not expose the stackTrace of the error, a simple message is enough to the consumer
                return StatusCode(500, " A problem happened while handling your request");
            }
        }

        [HttpGet("{pointofinterestId}", Name = "GetPointOfInterest")]

        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointofInterestId)
        {
            var cityExists = await _cityInfoRepository.CityExistsAsync(cityId);

            if (!cityExists)
            {
                _logger.LogInformation($"The city with Id {cityId} was not found.");
                return NotFound();
            }

            //Find point of interest
            var pointOfInterest = await _cityInfoRepository.GetPointOfInterestsForCityAsync(cityId, pointofInterestId);
            if (pointOfInterest == null)
            {
                _logger.LogInformation($"The point of interest with Id {pointofInterestId} was not found.");
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
        }

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(int cityId, /*This Attribute is not necessary since we're in an ApiController*/ [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {
            //Optional, managed by WebAPI
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var cityExists = await _cityInfoRepository.CityExistsAsync(cityId);

            if (!cityExists)
            {
                _logger.LogInformation($"The city with Id {cityId} was not found.");
                return NotFound();
            }

            var finalPointOfInterest = _mapper.Map<Entities.PointOfInterest>(pointOfInterest);

            await _cityInfoRepository.AddPointOfInterestForCityAsync(
                cityId, finalPointOfInterest);

            await _cityInfoRepository.SaveChangesAsync();

            var createdPointOfInterestToReturn = _mapper.Map<PointOfInterestDto>(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new { cityId, pointOfInterestId = createdPointOfInterestToReturn.Id },
                createdPointOfInterestToReturn
                );
        }

        [HttpPut("{pointofinterestId}")]
        public async Task<ActionResult> UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
        {
            var cityExists = await _cityInfoRepository.CityExistsAsync(cityId);

            if (!cityExists)
            {
                _logger.LogInformation($"The city with Id {cityId} was not found.");
                return NotFound();
            }

            //find point of interest
            var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestsForCityAsync(cityId, pointOfInterestId);
            if (pointOfInterestEntity == null) return NotFound();

            _mapper.Map(pointOfInterest, pointOfInterestEntity);

            await _cityInfoRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{pointofinterestId}")]
        public async Task<ActionResult> PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId, JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument /*Patch document is the list of operations we want to execute on our point of interest*/)
        {
            //find the city
            var cityExists = await _cityInfoRepository.CityExistsAsync(cityId);
            if (!cityExists) return NotFound();

            //find the point of interest
            var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestsForCityAsync(cityId, pointOfInterestId);

            if (pointOfInterestEntity == null)
                return NotFound();

            var pointOfInterestToPatch = _mapper.Map<PointOfInterestForUpdateDto>(pointOfInterestEntity);

            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            /*Verifying the ModelState after the patch application
             * take note that the input model is not the PointOfInterestForUpdateDto it is the JsonPatchDocument
             * so as long as the jsonpatch doc is valid according to the RFC standards then the model is valid*/

            if (!ModelState.IsValid) return BadRequest(ModelState);

            //Verify the PointOfInterestForUpdateDto input validity after applying the patch document
            if (!TryValidateModel(pointOfInterestToPatch))
                return BadRequest(ModelState);

            _mapper.Map(pointOfInterestToPatch, pointOfInterestEntity);
            await _cityInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{pointofinterestId}")]
        public async Task<ActionResult> DeletePointOfInterest(int cityId, int pointOfInterestId)
        {
            //Find the city
            var cityExists = await _cityInfoRepository.CityExistsAsync(cityId);
            if (!cityExists) return NotFound();

            //Find the point of interest
            var pointofInterestEntity = await _cityInfoRepository.GetPointOfInterestsForCityAsync(cityId, pointOfInterestId);
            if (pointofInterestEntity == null)
                return NotFound();

            _cityInfoRepository.DeletePointOfInterestForCity(pointofInterestEntity);
            await _cityInfoRepository.SaveChangesAsync();

            _localMailService.Send("Point of interest deleted ", $"Point of interest {pointofInterestEntity.Name} with Id {pointofInterestEntity.Id} was deleted");

            return NoContent();
        }


    }
}

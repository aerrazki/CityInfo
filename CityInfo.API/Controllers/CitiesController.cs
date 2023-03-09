using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ??
                throw new ArgumentNullException(nameof(cityInfoRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointOfInterestDto>>> GetCities()
        {
            var cityEntities = await _cityInfoRepository.GetCitiesAsync();

            return Ok(_mapper.Map<IEnumerable<CityWithoutPointOfInterestDto>>(cityEntities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int id, bool showPointOfInterest)
        {
            var cityEntity = await _cityInfoRepository.GetCityAsync(id, showPointOfInterest);
            return Ok(_mapper.Map<CityDto>(cityEntity));
        }


    }
}

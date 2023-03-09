using CityInfo.API.Entities;
namespace CityInfo.API.Services.Interfaces
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<bool> CityExistsAsync(int cityId);
        Task<City?> GetCityAsync(int cityId, bool includePointsOfInterests);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestsForCityAsync(int cityId);
        Task<PointOfInterest?> GetPointOfInterestsForCityAsync(int cityId, int pointOfInterestId);
        Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
        Task<bool> SaveChangesAsync();

    }

}

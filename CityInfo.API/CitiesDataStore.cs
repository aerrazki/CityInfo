using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            //Init dummy data
            Cities = new List<CityDto>()
        {
            new CityDto(){ Id=1,Name="Al Andalus", Description="Al andalus city where the golden age rised" },
            new CityDto(){ Id=2,Name="Fès", Description="City full of more than 12 centuries of history" },
            new CityDto(){ Id=3,Name="Rabat", Description="The capital city of Morocco" },
            new CityDto(){ Id=4,Name="Marrakesh", Description="The exotic city full of history" }

        };
        }
    }
}

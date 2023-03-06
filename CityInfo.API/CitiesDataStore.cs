using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            //Init dummy data
            Cities = new List<CityDto>() {
        new CityDto() {
            Id = 1, Name = "Al Andalus", Description = "Al andalus city where the golden age rised",
              PointsOfInterest = new List < PointOfInterestDto > () {
                new PointOfInterestDto() {
                    Id = 1, Name = "Qasr Al Hamraa", Description = "Magnificient place"
                  },
                  new PointOfInterestDto() {
                    Id = 2, Name = "The mosque of Al Andalus", Description = "Beautiful mosq built in the 7th century"
                  }
              }
          },
          new CityDto() {
            Id = 2,
              Name = "Fès",
              Description = "City full of more than 12 centuries of history",
              PointsOfInterest = new List < PointOfInterestDto > () {
                new PointOfInterestDto() {
                    Id = 1, Name = "University Al Quaraouiyine", Description = "One of the leading spiritual and educational centers in the islamic golden age"
                  },
                  new PointOfInterestDto() {
                    Id = 2, Name = "Old Bab bou jeloud", Description = "Gate surroundering the Old medina leading to Al Quaraouyine Mosque"
                  }
              }

          },
          new CityDto() {
            Id = 3, Name = "Rabat", Description = "The capital city of Morocco",
              PointsOfInterest = new List < PointOfInterestDto > () {
                new PointOfInterestDto() {
                    Id = 1, Name = "Hassan Tower", Description = "What's left of an ancient mosque"
                  },
                  new PointOfInterestDto() {
                    Id = 2, Name = "Kasbah of the udayas", Description = "An ancient Kasbah"
                  }
              }
          },
          new CityDto() {
            Id = 4, Name = "Marrakesh", Description = "The exotic city full of history",
              PointsOfInterest = new List < PointOfInterestDto > () {
                new PointOfInterestDto() {
                    Id = 1, Name = "Al kotoubia Mosque", Description = "An ancient mosque"
                  },
                  new PointOfInterestDto() {
                    Id = 2, Name = "Djemaa El fenna", Description = "An old square"
                  }
              }
          }

      };
        }
    }
}
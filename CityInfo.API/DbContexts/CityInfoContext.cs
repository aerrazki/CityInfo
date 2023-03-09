using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!; //Null forgiving operator
        public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;

        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed data
            modelBuilder.Entity<City>().HasData(
            new City("Paris") { Id = 1, Description = "The capital of France, A very european city" },
            new City("New York City") { Id = 2, Description = "The most populous city in the United States, known for its iconic skyline and cultural attractions" },
            new City("London") { Id = 3, Description = "The capital of England, known for its rich history, landmarks, and diverse culture" },
            new City("Tokyo") { Id = 4, Description = "The capital of Japan, known for its modern technology, vibrant nightlife, and traditional culture" },
            new City("Sydney") { Id = 5, Description = "The largest city in Australia, known for its beaches, landmarks, and cosmopolitan lifestyle" },
            new City("Rio de Janeiro") { Id = 6, Description = "A coastal city in Brazil, known for its natural beauty, cultural events, and Carnival celebration" }
             );

            modelBuilder.Entity<PointOfInterest>().HasData(
            new PointOfInterest("Eiffel Tower") { Id = 1, Description = "Tallest structure for 4 decades and a very known monument worldwide", CityId = 1 },
            new PointOfInterest("Louvre Museum") { Id = 2, Description = "One of the world's largest museums, home to many famous works of art including the Mona Lisa", CityId = 1 },
            new PointOfInterest("Champs-Élysées") { Id = 3, Description = "One of the most famous and luxurious avenues in the world, known for its high-end shops and cafes", CityId = 1 },
            new PointOfInterest("Statue of Liberty") { Id = 4, Description = "A symbol of freedom and democracy, gifted to the United States by France in 1886", CityId = 2 },
            new PointOfInterest("Central Park") { Id = 5, Description = "A massive park in the heart of Manhattan, featuring lakes, gardens, and various attractions", CityId = 2 },
            new PointOfInterest("Empire State Building") { Id = 6, Description = "A famous Art Deco skyscraper that offers stunning views of the city from its observation deck", CityId = 2 },
            new PointOfInterest("Big Ben") { Id = 7, Description = "The nickname for the clock tower of the Palace of Westminster, a symbol of British democracy and culture", CityId = 3 },
            new PointOfInterest("Tower Bridge") { Id = 8, Description = "A famous bridge over the River Thames, known for its distinctive towers and Victorian architecture", CityId = 3 },
            new PointOfInterest("British Museum") { Id = 9, Description = "One of the world's oldest and largest museums, with a vast collection of artifacts from around the globe", CityId = 3 },
            new PointOfInterest("Tokyo Skytree") { Id = 10, Description = "A broadcasting tower and observation deck, offering panoramic views of the city", CityId = 4 },
            new PointOfInterest("Shibuya Crossing") { Id = 11, Description = "One of the busiest pedestrian intersections in the world, with up to 3,000 people crossing at once", CityId = 4 },
            new PointOfInterest("Meiji Shrine") { Id = 12, Description = "A Shinto shrine dedicated to Emperor Meiji and Empress Shoken, surrounded by a tranquil forest in the heart of Tokyo", CityId = 4 },
            new PointOfInterest("Sydney Opera House") { Id = 13, Description = "A multi-venue performing arts center in Sydney, famous for its unique and iconic design", CityId = 5 },
            new PointOfInterest("Harbour Bridge") { Id = 14, Description = "A steel arch bridge that spans the Sydney Harbour, known for its scenic views and being a popular site for adventure tourism", CityId = 5 },
            new PointOfInterest("Bondi Beach") { Id = 15, Description = "A popular beach and coastal suburb in Sydney, known for its turquoise waters, golden sands, and laid-back lifestyle", CityId = 5 },
            new PointOfInterest("Christ the Redeemer") { Id = 16, Description = "A statue of Jesus Christ in Rio de Janeiro, one of the world's most famous and iconic religious monuments", CityId = 6 },
            new PointOfInterest("Copacabana Beach") { Id = 17, Description = "A long, crescent-shaped beach in Rio de Janeiro, famous for its golden sands and for its lively atmosphere, beach sports, and many beachfront bars and restaurants", CityId = 6 }
            );

            base.OnModelCreating(modelBuilder);
        }
        //A way to connect to the database - Override configuring method to set up a connection string

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}

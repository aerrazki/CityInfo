using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    public partial class SeedingDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "The capital of France, A very european city", "Paris" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "The most populous city in the United States, known for its iconic skyline and cultural attractions", "New York City" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "The capital of England, known for its rich history, landmarks, and diverse culture", "London" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 4, "The capital of Japan, known for its modern technology, vibrant nightlife, and traditional culture", "Tokyo" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 5, "The largest city in Australia, known for its beaches, landmarks, and cosmopolitan lifestyle", "Sydney" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 6, "A coastal city in Brazil, known for its natural beauty, cultural events, and Carnival celebration", "Rio de Janeiro" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 1, 1, "Tallest structure for 4 decades and a very known monument worldwide", "Eiffel Tower" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 2, 1, "One of the world's largest museums, home to many famous works of art including the Mona Lisa", "Louvre Museum" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 3, 1, "One of the most famous and luxurious avenues in the world, known for its high-end shops and cafes", "Champs-Élysées" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 4, 2, "A symbol of freedom and democracy, gifted to the United States by France in 1886", "Statue of Liberty" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 5, 2, "A massive park in the heart of Manhattan, featuring lakes, gardens, and various attractions", "Central Park" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 6, 2, "A famous Art Deco skyscraper that offers stunning views of the city from its observation deck", "Empire State Building" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 7, 3, "The nickname for the clock tower of the Palace of Westminster, a symbol of British democracy and culture", "Big Ben" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 8, 3, "A famous bridge over the River Thames, known for its distinctive towers and Victorian architecture", "Tower Bridge" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 9, 3, "One of the world's oldest and largest museums, with a vast collection of artifacts from around the globe", "British Museum" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 10, 4, "A broadcasting tower and observation deck, offering panoramic views of the city", "Tokyo Skytree" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 11, 4, "One of the busiest pedestrian intersections in the world, with up to 3,000 people crossing at once", "Shibuya Crossing" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 12, 4, "A Shinto shrine dedicated to Emperor Meiji and Empress Shoken, surrounded by a tranquil forest in the heart of Tokyo", "Meiji Shrine" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 13, 5, "A multi-venue performing arts center in Sydney, famous for its unique and iconic design", "Sydney Opera House" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 14, 5, "A steel arch bridge that spans the Sydney Harbour, known for its scenic views and being a popular site for adventure tourism", "Harbour Bridge" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 15, 5, "A popular beach and coastal suburb in Sydney, known for its turquoise waters, golden sands, and laid-back lifestyle", "Bondi Beach" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 16, 6, "A statue of Jesus Christ in Rio de Janeiro, one of the world's most famous and iconic religious monuments", "Christ the Redeemer" });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[] { 17, 6, "A long, crescent-shaped beach in Rio de Janeiro, famous for its golden sands and for its lively atmosphere, beach sports, and many beachfront bars and restaurants", "Copacabana Beach" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

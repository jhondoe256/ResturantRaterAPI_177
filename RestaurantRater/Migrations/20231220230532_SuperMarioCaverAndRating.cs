using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantRater.Migrations
{
    /// <inheritdoc />
    public partial class SuperMarioCaverAndRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "ID", "Address", "Name" },
                values: new object[] { 1, "1Up Lane", "Super Mario Pasta Cavern" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "ID", "CleanlinessScore", "EnvironmentScore", "FoodScore", "RestaurantID" },
                values: new object[,]
                {
                    { 1, 10.0, 8.8000000000000007, 7.5, 1 },
                    { 2, 9.9000000000000004, 9.8000000000000007, 8.5, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}

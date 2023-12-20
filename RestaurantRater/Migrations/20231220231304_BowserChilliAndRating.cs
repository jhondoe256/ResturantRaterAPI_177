using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantRater.Migrations
{
    /// <inheritdoc />
    public partial class BowserChilliAndRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "ID", "Address", "Name" },
                values: new object[] { 2, "123 GRRRR Court", "Bowsers Hot Chilli Shop!" });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "ID", "CleanlinessScore", "EnvironmentScore", "FoodScore", "RestaurantID" },
                values: new object[,]
                {
                    { 3, 10.0, 5.7999999999999998, 3.5, 2 },
                    { 4, 7.0, 6.7999999999999998, 6.5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantRater.Migrations
{
    /// <inheritdoc />
    public partial class AddingOwnerNameToRestaurantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Restaurants");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestiuneRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class AdaugareStareMasa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stare",
                table: "Masa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stare",
                table: "Masa");
        }
    }
}

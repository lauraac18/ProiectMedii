using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestiuneRestaurant.Migrations
{
    /// <inheritdoc />
    public partial class AdaugareNrPersoane : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumarPersoane",
                table: "Rezervare",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumarPersoane",
                table: "Rezervare");
        }
    }
}

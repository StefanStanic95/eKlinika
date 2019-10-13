using Microsoft.EntityFrameworkCore.Migrations;

namespace eKlinika.Migrations
{
    public partial class recept_kolicina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "Recept",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Recept");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace eKlinika.WebAPI.Migrations
{
    public partial class narudzba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iznos",
                table: "Narudzba");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Iznos",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}

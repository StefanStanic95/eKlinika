using Microsoft.EntityFrameworkCore.Migrations;

namespace eKlinika.Migrations
{
    public partial class narudzba_iznos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Iznos",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iznos",
                table: "Narudzba");
        }
    }
}

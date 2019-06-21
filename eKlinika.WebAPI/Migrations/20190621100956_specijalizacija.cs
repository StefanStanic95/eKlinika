using Microsoft.EntityFrameworkCore.Migrations;

namespace eKlinika.WebAPI.Migrations
{
    public partial class specijalizacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoktorSpecijalizacija",
                table: "Dijagnoza",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoktorSpecijalizacija",
                table: "Dijagnoza");
        }
    }
}

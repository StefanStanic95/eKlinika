using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKlinika.WebAPI.Migrations
{
    public partial class ApotekaRacun_DatumUplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumUplate",
                table: "ApotekaRacun",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumUplate",
                table: "ApotekaRacun");
        }
    }
}

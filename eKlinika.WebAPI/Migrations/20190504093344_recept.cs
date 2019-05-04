using Microsoft.EntityFrameworkCore.Migrations;

namespace eKlinika.WebAPI.Migrations
{
    public partial class recept : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApotekaRacun_Pacijent_PacijentId",
                table: "ApotekaRacun");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_Pacijent_PacijentId",
                table: "Pregled");

            migrationBuilder.DropForeignKey(
                name: "FK_RezultatPretrage_Uputnica_UputnicaId",
                table: "RezultatPretrage");

            migrationBuilder.DropForeignKey(
                name: "FK_Uputnica_Pacijent_PacijentId",
                table: "Uputnica");

            migrationBuilder.DropColumn(
                name: "Kolicina",
                table: "Recept");

            migrationBuilder.AddForeignKey(
                name: "FK_ApotekaRacun_Pacijent_PacijentId",
                table: "ApotekaRacun",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_Pacijent_PacijentId",
                table: "Pregled",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RezultatPretrage_Uputnica_UputnicaId",
                table: "RezultatPretrage",
                column: "UputnicaId",
                principalTable: "Uputnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uputnica_Pacijent_PacijentId",
                table: "Uputnica",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApotekaRacun_Pacijent_PacijentId",
                table: "ApotekaRacun");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_Pacijent_PacijentId",
                table: "Pregled");

            migrationBuilder.DropForeignKey(
                name: "FK_RezultatPretrage_Uputnica_UputnicaId",
                table: "RezultatPretrage");

            migrationBuilder.DropForeignKey(
                name: "FK_Uputnica_Pacijent_PacijentId",
                table: "Uputnica");

            migrationBuilder.AddColumn<int>(
                name: "Kolicina",
                table: "Recept",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ApotekaRacun_Pacijent_PacijentId",
                table: "ApotekaRacun",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_Pacijent_PacijentId",
                table: "Pregled",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RezultatPretrage_Uputnica_UputnicaId",
                table: "RezultatPretrage",
                column: "UputnicaId",
                principalTable: "Uputnica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uputnica_Pacijent_PacijentId",
                table: "Uputnica",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

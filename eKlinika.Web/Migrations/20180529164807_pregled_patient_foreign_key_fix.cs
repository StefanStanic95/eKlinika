using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eKlinika.Migrations
{
    public partial class pregled_patient_foreign_key_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PacijentId",
                table: "Pregled",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_PacijentId",
                table: "Pregled",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_UplataId",
                table: "Pregled",
                column: "UplataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_Pacijent_PacijentId",
                table: "Pregled",
                column: "PacijentId",
                principalTable: "Pacijent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pregled_Uplata_UplataId",
                table: "Pregled",
                column: "UplataId",
                principalTable: "Uplata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_Pacijent_PacijentId",
                table: "Pregled");

            migrationBuilder.DropForeignKey(
                name: "FK_Pregled_Uplata_UplataId",
                table: "Pregled");

            migrationBuilder.DropIndex(
                name: "IX_Pregled_PacijentId",
                table: "Pregled");

            migrationBuilder.DropIndex(
                name: "IX_Pregled_UplataId",
                table: "Pregled");

            migrationBuilder.DropColumn(
                name: "PacijentId",
                table: "Pregled");
        }
    }
}

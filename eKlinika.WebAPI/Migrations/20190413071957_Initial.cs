using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eKlinika.WebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dijagnoza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true),
                    StrucniOpis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dijagnoza", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    Oznaka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KrvnaGrupa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrvnaGrupa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kontakt = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaPretrage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaPretrage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dobavljac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaId = table.Column<int>(nullable: false),
                    Kontakt = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dobavljac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dobavljac_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lijek",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CijenaPoKomadu = table.Column<double>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    PoReceptu = table.Column<bool>(nullable: false),
                    ProizvodjacId = table.Column<int>(nullable: false),
                    Tip = table.Column<string>(nullable: true),
                    UkupnoNaStanju = table.Column<int>(nullable: false),
                    Uputstvo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lijek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lijek_Proizvodjac_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabPretraga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MjernaJedinica = table.Column<string>(nullable: true),
                    Naziv = table.Column<string>(nullable: true),
                    ReferentnaVrijednostDonja = table.Column<double>(nullable: false),
                    ReferentnaVrijednostGornja = table.Column<double>(nullable: false),
                    VrstaPretrageId = table.Column<int>(nullable: false),
                    VrstaVr = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabPretraga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabPretraga_VrstaPretrage_VrstaPretrageId",
                        column: x => x.VrstaPretrageId,
                        principalTable: "VrstaPretrage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumIsporuke = table.Column<DateTime>(nullable: true),
                    DatumNarudzbe = table.Column<DateTime>(nullable: false),
                    DobavljacId = table.Column<int>(nullable: false),
                    Iznos = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzba_Dobavljac_DobavljacId",
                        column: x => x.DobavljacId,
                        principalTable: "Dobavljac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    GradId = table.Column<int>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    Slika = table.Column<byte[]>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    Ulica = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modalitet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LabPretragaId = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    isReferentnaVrijednost = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalitet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modalitet_LabPretraga_LabPretragaId",
                        column: x => x.LabPretragaId,
                        principalTable: "LabPretraga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kolicina = table.Column<int>(nullable: false),
                    LijekId = table.Column<int>(nullable: false),
                    NarudzbaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Lijek_LijekId",
                        column: x => x.LijekId,
                        principalTable: "Lijek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaStavka_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Osoblje",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DatumZaposlenja = table.Column<DateTime>(nullable: false),
                    GodineStaza = table.Column<int>(nullable: false),
                    Jezici = table.Column<string>(nullable: true),
                    TipZaposlenja = table.Column<string>(nullable: true),
                    TrajanjeUgovora = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Osoblje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Osoblje_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacijent",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Alergije = table.Column<string>(nullable: true),
                    BrojKartona = table.Column<string>(nullable: true),
                    BrojKnjizice = table.Column<string>(nullable: true),
                    DatumRegistracije = table.Column<DateTime>(nullable: false),
                    KrvnaGrupaId = table.Column<int>(nullable: false),
                    SpecijalniZahtjevi = table.Column<string>(nullable: true),
                    Tezina = table.Column<double>(nullable: false),
                    Visina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacijent_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacijent_KrvnaGrupa_KrvnaGrupaId",
                        column: x => x.KrvnaGrupaId,
                        principalTable: "KrvnaGrupa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apotekar",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OpisPosla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apotekar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apotekar_Osoblje_Id",
                        column: x => x.Id,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doktor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DatumSpecijalizacije = table.Column<DateTime>(nullable: false),
                    Specijalizacija = table.Column<string>(nullable: true),
                    Titula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doktor_Osoblje_Id",
                        column: x => x.Id,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicinskaSestra",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Certifikati = table.Column<string>(nullable: true),
                    Kursevi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinskaSestra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicinskaSestra_Osoblje_Id",
                        column: x => x.Id,
                        principalTable: "Osoblje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojUplatnice = table.Column<string>(nullable: true),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<double>(nullable: false),
                    Namjena = table.Column<string>(nullable: true),
                    PacijentId = table.Column<string>(nullable: true),
                    PregledId = table.Column<int>(nullable: true),
                    ZiroRacun = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplata_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApotekaRacun",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApotekarId = table.Column<string>(nullable: true),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false),
                    PacijentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApotekaRacun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApotekaRacun_Apotekar_ApotekarId",
                        column: x => x.ApotekarId,
                        principalTable: "Apotekar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApotekaRacun_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Uputnica",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumRezultata = table.Column<DateTime>(nullable: false),
                    DatumUputnice = table.Column<DateTime>(nullable: false),
                    IsGotovNalaz = table.Column<bool>(nullable: false),
                    LaboratorijDoktorId = table.Column<string>(nullable: true),
                    PacijentId = table.Column<string>(nullable: true),
                    UputioDoktorId = table.Column<string>(nullable: true),
                    VrstaPretrageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uputnica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uputnica_Doktor_LaboratorijDoktorId",
                        column: x => x.LaboratorijDoktorId,
                        principalTable: "Doktor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uputnica_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uputnica_Doktor_UputioDoktorId",
                        column: x => x.UputioDoktorId,
                        principalTable: "Doktor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Uputnica_VrstaPretrage_VrstaPretrageId",
                        column: x => x.VrstaPretrageId,
                        principalTable: "VrstaPretrage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pregled",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumPregleda = table.Column<DateTime>(nullable: false),
                    DatumRezervacije = table.Column<DateTime>(nullable: false),
                    DoktorId = table.Column<string>(nullable: true),
                    MedicinskaSestraId = table.Column<string>(nullable: true),
                    Napomena = table.Column<string>(nullable: true),
                    Prioritet = table.Column<string>(nullable: true),
                    TipPregleda = table.Column<string>(nullable: true),
                    UplataId = table.Column<int>(nullable: true),
                    isOdrzan = table.Column<bool>(nullable: false),
                    PacijentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregled", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregled_Doktor_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pregled_MedicinskaSestra_MedicinskaSestraId",
                        column: x => x.MedicinskaSestraId,
                        principalTable: "MedicinskaSestra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pregled_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pregled_Uplata_UplataId",
                        column: x => x.UplataId,
                        principalTable: "Uplata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RacunStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApotekaRacunId = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    LijekId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacunStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RacunStavka_ApotekaRacun_ApotekaRacunId",
                        column: x => x.ApotekaRacunId,
                        principalTable: "ApotekaRacun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacunStavka_Lijek_LijekId",
                        column: x => x.LijekId,
                        principalTable: "Lijek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RezultatPretrage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LabPretragaId = table.Column<int>(nullable: false),
                    ModalitetId = table.Column<int>(nullable: true),
                    NumerickaVrijednost = table.Column<double>(nullable: true),
                    UputnicaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezultatPretrage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezultatPretrage_LabPretraga_LabPretragaId",
                        column: x => x.LabPretragaId,
                        principalTable: "LabPretraga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezultatPretrage_Modalitet_ModalitetId",
                        column: x => x.ModalitetId,
                        principalTable: "Modalitet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezultatPretrage_Uputnica_UputnicaId",
                        column: x => x.UputnicaId,
                        principalTable: "Uputnica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recept",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    LijekId = table.Column<int>(nullable: false),
                    PregledId = table.Column<int>(nullable: false),
                    Uputstvo = table.Column<string>(nullable: true),
                    IsObradjen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recept", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recept_Lijek_LijekId",
                        column: x => x.LijekId,
                        principalTable: "Lijek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recept_Pregled_PregledId",
                        column: x => x.PregledId,
                        principalTable: "Pregled",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UstanovljenaDijagnoza",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalji = table.Column<string>(nullable: true),
                    DijagnozaId = table.Column<int>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    PregledId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UstanovljenaDijagnoza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UstanovljenaDijagnoza_Dijagnoza_DijagnozaId",
                        column: x => x.DijagnozaId,
                        principalTable: "Dijagnoza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UstanovljenaDijagnoza_Pregled_PregledId",
                        column: x => x.PregledId,
                        principalTable: "Pregled",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApotekaRacun_ApotekarId",
                table: "ApotekaRacun",
                column: "ApotekarId");

            migrationBuilder.CreateIndex(
                name: "IX_ApotekaRacun_PacijentId",
                table: "ApotekaRacun",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GradId",
                table: "AspNetUsers",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dobavljac_DrzavaId",
                table: "Dobavljac",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaId",
                table: "Grad",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_LabPretraga_VrstaPretrageId",
                table: "LabPretraga",
                column: "VrstaPretrageId");

            migrationBuilder.CreateIndex(
                name: "IX_Lijek_ProizvodjacId",
                table: "Lijek",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Modalitet_LabPretragaId",
                table: "Modalitet",
                column: "LabPretragaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_DobavljacId",
                table: "Narudzba",
                column: "DobavljacId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_LijekId",
                table: "NarudzbaStavka",
                column: "LijekId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaStavka_NarudzbaId",
                table: "NarudzbaStavka",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacijent_KrvnaGrupaId",
                table: "Pacijent",
                column: "KrvnaGrupaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_DoktorId",
                table: "Pregled",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_MedicinskaSestraId",
                table: "Pregled",
                column: "MedicinskaSestraId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_PacijentId",
                table: "Pregled",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregled_UplataId",
                table: "Pregled",
                column: "UplataId");

            migrationBuilder.CreateIndex(
                name: "IX_RacunStavka_ApotekaRacunId",
                table: "RacunStavka",
                column: "ApotekaRacunId");

            migrationBuilder.CreateIndex(
                name: "IX_RacunStavka_LijekId",
                table: "RacunStavka",
                column: "LijekId");

            migrationBuilder.CreateIndex(
                name: "IX_Recept_LijekId",
                table: "Recept",
                column: "LijekId");

            migrationBuilder.CreateIndex(
                name: "IX_Recept_PregledId",
                table: "Recept",
                column: "PregledId");

            migrationBuilder.CreateIndex(
                name: "IX_RezultatPretrage_LabPretragaId",
                table: "RezultatPretrage",
                column: "LabPretragaId");

            migrationBuilder.CreateIndex(
                name: "IX_RezultatPretrage_ModalitetId",
                table: "RezultatPretrage",
                column: "ModalitetId");

            migrationBuilder.CreateIndex(
                name: "IX_RezultatPretrage_UputnicaId",
                table: "RezultatPretrage",
                column: "UputnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_PacijentId",
                table: "Uplata",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_LaboratorijDoktorId",
                table: "Uputnica",
                column: "LaboratorijDoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_PacijentId",
                table: "Uputnica",
                column: "PacijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_UputioDoktorId",
                table: "Uputnica",
                column: "UputioDoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Uputnica_VrstaPretrageId",
                table: "Uputnica",
                column: "VrstaPretrageId");

            migrationBuilder.CreateIndex(
                name: "IX_UstanovljenaDijagnoza_DijagnozaId",
                table: "UstanovljenaDijagnoza",
                column: "DijagnozaId");

            migrationBuilder.CreateIndex(
                name: "IX_UstanovljenaDijagnoza_PregledId",
                table: "UstanovljenaDijagnoza",
                column: "PregledId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "NarudzbaStavka");

            migrationBuilder.DropTable(
                name: "RacunStavka");

            migrationBuilder.DropTable(
                name: "Recept");

            migrationBuilder.DropTable(
                name: "RezultatPretrage");

            migrationBuilder.DropTable(
                name: "UstanovljenaDijagnoza");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "ApotekaRacun");

            migrationBuilder.DropTable(
                name: "Lijek");

            migrationBuilder.DropTable(
                name: "Modalitet");

            migrationBuilder.DropTable(
                name: "Uputnica");

            migrationBuilder.DropTable(
                name: "Dijagnoza");

            migrationBuilder.DropTable(
                name: "Pregled");

            migrationBuilder.DropTable(
                name: "Dobavljac");

            migrationBuilder.DropTable(
                name: "Apotekar");

            migrationBuilder.DropTable(
                name: "Proizvodjac");

            migrationBuilder.DropTable(
                name: "LabPretraga");

            migrationBuilder.DropTable(
                name: "Doktor");

            migrationBuilder.DropTable(
                name: "MedicinskaSestra");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "VrstaPretrage");

            migrationBuilder.DropTable(
                name: "Osoblje");

            migrationBuilder.DropTable(
                name: "Pacijent");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "KrvnaGrupa");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}

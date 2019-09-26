﻿// <auto-generated />
using eKlinika.Data;
using eKlinika.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace eKlinika.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180529164807_pregled_patient_foreign_key_fix")]
    partial class pregled_patient_foreign_key_fix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eKlinika.Models.Apotekar", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("OpisPosla");

                    b.HasKey("Id");

                    b.ToTable("Apotekar");
                });

            modelBuilder.Entity("eKlinika.Models.ApotekaRacun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApotekarId");

                    b.Property<DateTime>("DatumIzdavanja");

                    b.Property<string>("PacijentId");

                    b.HasKey("Id");

                    b.HasIndex("ApotekarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("ApotekaRacun");
                });

            modelBuilder.Entity("eKlinika.Models.Korisnici", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");
;

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("GradId");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Prezime");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Slika");

                    b.Property<string>("Spol");
                    

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("Ulica");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("eKlinika.Models.Dijagnoza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Opis");

                    b.Property<string>("StrucniOpis");

                    b.HasKey("Id");

                    b.ToTable("Dijagnoza");
                });

            modelBuilder.Entity("eKlinika.Models.Dobavljac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Kontakt");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Dobavljac");
                });

            modelBuilder.Entity("eKlinika.Models.Doktor", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("DatumSpecijalizacije");

                    b.Property<string>("Specijalizacija");

                    b.Property<string>("Titula");

                    b.HasKey("Id");

                    b.ToTable("Doktor");
                });

            modelBuilder.Entity("eKlinika.Models.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.Property<string>("Oznaka");

                    b.HasKey("Id");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("eKlinika.Models.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Naziv");

                    b.Property<string>("PostanskiBroj");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("eKlinika.Models.KrvnaGrupa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("KrvnaGrupa");
                });

            modelBuilder.Entity("eKlinika.Models.LabPretraga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MjernaJedinica");

                    b.Property<string>("Naziv");

                    b.Property<double>("ReferentnaVrijednostDonja");

                    b.Property<double>("ReferentnaVrijednostGornja");

                    b.Property<int>("VrstaPretrageId");

                    b.Property<int>("VrstaVr");

                    b.HasKey("Id");

                    b.HasIndex("VrstaPretrageId");

                    b.ToTable("LabPretraga");
                });

            modelBuilder.Entity("eKlinika.Models.Lijek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CijenaPoKomadu");

                    b.Property<string>("Naziv");

                    b.Property<bool>("PoReceptu");

                    b.Property<int>("ProizvodjacId");

                    b.Property<string>("Tip");

                    b.Property<int>("UkupnoNaStanju");

                    b.Property<string>("Uputstvo");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodjacId");

                    b.ToTable("Lijek");
                });

            modelBuilder.Entity("eKlinika.Models.MedicinskaSestra", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Certifikati");

                    b.Property<string>("Kursevi");

                    b.HasKey("Id");

                    b.ToTable("MedicinskaSestra");
                });

            modelBuilder.Entity("eKlinika.Models.Modalitet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LabPretragaId");

                    b.Property<string>("Opis");

                    b.Property<bool>("isReferentnaVrijednost");

                    b.HasKey("Id");

                    b.HasIndex("LabPretragaId");

                    b.ToTable("Modalitet");
                });

            modelBuilder.Entity("eKlinika.Models.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumIsporuke");

                    b.Property<DateTime>("DatumNarudzbe");

                    b.Property<int>("DobavljacId");

                    b.Property<double>("Iznos");

                    b.HasKey("Id");

                    b.HasIndex("DobavljacId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("eKlinika.Models.NarudzbaStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Kolicina");

                    b.Property<int>("LijekId");

                    b.Property<int>("NarudzbaId");

                    b.HasKey("Id");

                    b.HasIndex("LijekId");

                    b.HasIndex("NarudzbaId");

                    b.ToTable("NarudzbaStavka");
                });

            modelBuilder.Entity("eKlinika.Models.Osoblje", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("DatumZaposlenja");

                    b.Property<int>("GodineStaza");

                    b.Property<string>("Jezici");

                    b.Property<string>("TipZaposlenja");

                    b.Property<string>("TrajanjeUgovora");

                    b.HasKey("Id");

                    b.ToTable("Osoblje");
                });

            modelBuilder.Entity("eKlinika.Models.Pacijent", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Alergije");

                    b.Property<string>("BrojKartona");

                    b.Property<string>("BrojKnjizice");

                    b.Property<DateTime>("DatumRegistracije");

                    b.Property<int>("KrvnaGrupaId");

                    b.Property<string>("SpecijalniZahtjevi");

                    b.Property<double>("Tezina");

                    b.Property<int>("Visina");

                    b.HasKey("Id");

                    b.HasIndex("KrvnaGrupaId");

                    b.ToTable("Pacijent");
                });

            modelBuilder.Entity("eKlinika.Models.Pregled", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumPregleda");

                    b.Property<DateTime>("DatumRezervacije");

                    b.Property<string>("DoktorId");

                    b.Property<string>("MedicinskaSestraId");

                    b.Property<string>("Napomena");

                    b.Property<string>("PacijentId");

                    b.Property<string>("Prioritet");

                    b.Property<string>("TipPregleda");

                    b.Property<int?>("UplataId");

                    b.Property<bool>("isOdrzan");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("MedicinskaSestraId");

                    b.HasIndex("PacijentId");

                    b.HasIndex("UplataId");

                    b.ToTable("Pregled");
                });

            modelBuilder.Entity("eKlinika.Models.Proizvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Kontakt");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Proizvodjac");
                });

            modelBuilder.Entity("eKlinika.Models.RacunStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApotekaRacunId");

                    b.Property<int>("Kolicina");

                    b.Property<int>("LijekId");

                    b.HasKey("Id");

                    b.HasIndex("ApotekaRacunId");

                    b.HasIndex("LijekId");

                    b.ToTable("RacunStavka");
                });

            modelBuilder.Entity("eKlinika.Models.Recept", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumIzdavanja");

                    b.Property<int>("Kolicina");

                    b.Property<int>("LijekId");

                    b.Property<int>("PregledId");

                    b.Property<string>("Uputstvo");

                    b.HasKey("Id");

                    b.HasIndex("LijekId");

                    b.HasIndex("PregledId");

                    b.ToTable("Recept");
                });

            modelBuilder.Entity("eKlinika.Models.RezultatPretrage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LabPretragaId");

                    b.Property<int?>("ModalitetId");

                    b.Property<double?>("NumerickaVrijednost");

                    b.Property<int>("UputnicaId");

                    b.HasKey("Id");

                    b.HasIndex("LabPretragaId");

                    b.HasIndex("ModalitetId");

                    b.HasIndex("UputnicaId");

                    b.ToTable("RezultatPretrage");
                });

            modelBuilder.Entity("eKlinika.Models.Uplata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojUplatnice");

                    b.Property<DateTime>("DatumUplate");

                    b.Property<double>("Iznos");

                    b.Property<string>("Namjena");

                    b.Property<string>("PacijentId");

                    b.Property<int?>("PregledId");

                    b.Property<string>("ZiroRacun");

                    b.HasKey("Id");

                    b.HasIndex("PacijentId");

                    b.ToTable("Uplata");
                });

            modelBuilder.Entity("eKlinika.Models.Uputnica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumRezultata");

                    b.Property<DateTime>("DatumUputnice");

                    b.Property<bool>("IsGotovNalaz");

                    b.Property<string>("LaboratorijDoktorId");

                    b.Property<string>("PacijentId");

                    b.Property<string>("UputioDoktorId");

                    b.Property<int>("VrstaPretrageId");

                    b.HasKey("Id");

                    b.HasIndex("LaboratorijDoktorId");

                    b.HasIndex("PacijentId");

                    b.HasIndex("UputioDoktorId");

                    b.HasIndex("VrstaPretrageId");

                    b.ToTable("Uputnica");
                });

            modelBuilder.Entity("eKlinika.Models.UstanovljenaDijagnoza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Detalji");

                    b.Property<int>("DijagnozaId");

                    b.Property<string>("Napomena");

                    b.Property<int>("PregledId");

                    b.HasKey("Id");

                    b.HasIndex("DijagnozaId");

                    b.HasIndex("PregledId");

                    b.ToTable("UstanovljenaDijagnoza");
                });

            modelBuilder.Entity("eKlinika.Models.VrstaPretrage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("VrstaPretrage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("eKlinika.Models.Apotekar", b =>
                {
                    b.HasOne("eKlinika.Models.Osoblje", "Osoblje")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.ApotekaRacun", b =>
                {
                    b.HasOne("eKlinika.Models.Apotekar", "Apotekar")
                        .WithMany()
                        .HasForeignKey("ApotekarId");

                    b.HasOne("eKlinika.Models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId");
                });

            modelBuilder.Entity("eKlinika.Models.Korisnici", b =>
                {
                    b.HasOne("eKlinika.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId");
                });

            modelBuilder.Entity("eKlinika.Models.Dobavljac", b =>
                {
                    b.HasOne("eKlinika.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.Doktor", b =>
                {
                    b.HasOne("eKlinika.Models.Osoblje", "Osoblje")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.Grad", b =>
                {
                    b.HasOne("eKlinika.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.LabPretraga", b =>
                {
                    b.HasOne("eKlinika.Models.VrstaPretrage", "VrstaPretrage")
                        .WithMany()
                        .HasForeignKey("VrstaPretrageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.Lijek", b =>
                {
                    b.HasOne("eKlinika.Models.Proizvodjac", "Proizvodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.MedicinskaSestra", b =>
                {
                    b.HasOne("eKlinika.Models.Osoblje", "Osoblje")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.Modalitet", b =>
                {
                    b.HasOne("eKlinika.Models.LabPretraga", "LabPretraga")
                        .WithMany()
                        .HasForeignKey("LabPretragaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.Narudzba", b =>
                {
                    b.HasOne("eKlinika.Models.Dobavljac", "Dobavljac")
                        .WithMany()
                        .HasForeignKey("DobavljacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.NarudzbaStavka", b =>
                {
                    b.HasOne("eKlinika.Models.Lijek", "Lijek")
                        .WithMany()
                        .HasForeignKey("LijekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.Osoblje", b =>
                {
                    b.HasOne("eKlinika.Models.Korisnici", "Korisnici")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.Pacijent", b =>
                {
                    b.HasOne("eKlinika.Models.Korisnici", "Korisnici")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.KrvnaGrupa", "KrvnaGrupa")
                        .WithMany()
                        .HasForeignKey("KrvnaGrupaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.Pregled", b =>
                {
                    b.HasOne("eKlinika.Models.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId");

                    b.HasOne("eKlinika.Models.MedicinskaSestra", "MedicinskaSestra")
                        .WithMany()
                        .HasForeignKey("MedicinskaSestraId");

                    b.HasOne("eKlinika.Models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId");

                    b.HasOne("eKlinika.Models.Uplata", "Uplata")
                        .WithMany()
                        .HasForeignKey("UplataId");
                });

            modelBuilder.Entity("eKlinika.Models.RacunStavka", b =>
                {
                    b.HasOne("eKlinika.Models.ApotekaRacun", "ApotekaRacun")
                        .WithMany()
                        .HasForeignKey("ApotekaRacunId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Lijek", "Lijek")
                        .WithMany()
                        .HasForeignKey("LijekId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.Recept", b =>
                {
                    b.HasOne("eKlinika.Models.Lijek", "Lijek")
                        .WithMany()
                        .HasForeignKey("LijekId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Pregled", "Pregled")
                        .WithMany()
                        .HasForeignKey("PregledId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.RezultatPretrage", b =>
                {
                    b.HasOne("eKlinika.Models.LabPretraga", "LabPretraga")
                        .WithMany()
                        .HasForeignKey("LabPretragaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Modalitet", "Modalitet")
                        .WithMany()
                        .HasForeignKey("ModalitetId");

                    b.HasOne("eKlinika.Models.Uputnica", "Uputnica")
                        .WithMany()
                        .HasForeignKey("UputnicaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eKlinika.Models.Uplata", b =>
                {
                    b.HasOne("eKlinika.Models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId");
                });

            modelBuilder.Entity("eKlinika.Models.Uputnica", b =>
                {
                    b.HasOne("eKlinika.Models.Doktor", "LaboratorijDoktor")
                        .WithMany()
                        .HasForeignKey("LaboratorijDoktorId");

                    b.HasOne("eKlinika.Models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId");

                    b.HasOne("eKlinika.Models.Doktor", "UputioDoktor")
                        .WithMany()
                        .HasForeignKey("UputioDoktorId");

                    b.HasOne("eKlinika.Models.VrstaPretrage", "VrstaPretrage")
                        .WithMany()
                        .HasForeignKey("VrstaPretrageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.UstanovljenaDijagnoza", b =>
                {
                    b.HasOne("eKlinika.Models.Dijagnoza", "Dijagnoza")
                        .WithMany()
                        .HasForeignKey("DijagnozaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Pregled", "Pregled")
                        .WithMany()
                        .HasForeignKey("PregledId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("eKlinika.Models.Korisnici")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("eKlinika.Models.Korisnici")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Korisnici")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("eKlinika.Models.Korisnici")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

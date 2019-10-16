﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eKlinika.Data;

namespace eKlinika.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191013113310_recept_kolicina")]
    partial class recept_kolicina
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eKlinika.Models.Apotekar", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("OpisPosla");

                    b.HasKey("Id");

                    b.ToTable("Apotekar");
                });

            modelBuilder.Entity("eKlinika.Models.ApotekaRacun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApotekarId");

                    b.Property<DateTime>("DatumIzdavanja");

                    b.Property<int>("PacijentId");

                    b.HasKey("Id");

                    b.HasIndex("ApotekarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("ApotekaRacun");
                });

            modelBuilder.Entity("eKlinika.Models.AutorizacijskiToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IpAdresa");

                    b.Property<int>("KorisniciId");

                    b.Property<string>("Vrijednost");

                    b.Property<DateTime>("VrijemeEvidentiranja");

                    b.HasKey("Id");

                    b.HasIndex("KorisniciId");

                    b.ToTable("AutorizacijskiToken");
                });

            modelBuilder.Entity("eKlinika.Models.Dijagnoza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Opis");

                    b.Property<string>("StrucniOpis");

                    b.HasKey("Id");

                    b.ToTable("Dijagnoza");
                });

            modelBuilder.Entity("eKlinika.Models.Dobavljac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Kontakt");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Dobavljac");
                });

            modelBuilder.Entity("eKlinika.Models.Doktor", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("DatumSpecijalizacije");

                    b.Property<string>("Specijalizacija");

                    b.Property<string>("Titula");

                    b.HasKey("Id");

                    b.ToTable("Doktor");
                });

            modelBuilder.Entity("eKlinika.Models.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Oznaka");

                    b.HasKey("Id");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("eKlinika.Models.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Naziv");

                    b.Property<string>("PostanskiBroj");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("eKlinika.Models.Korisnici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Broj");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<string>("Email");

                    b.Property<int?>("GradId");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<string>("LozinkaHash");

                    b.Property<string>("LozinkaSalt");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Prezime");

                    b.Property<byte[]>("Slika");

                    b.Property<string>("Spol");

                    b.Property<string>("Telefon");

                    b.Property<string>("Ulica");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("eKlinika.Models.KorisniciUloge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KorisnikId");

                    b.Property<int>("UlogaId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("UlogaId");

                    b.ToTable("KorisniciUloge");
                });

            modelBuilder.Entity("eKlinika.Models.KrvnaGrupa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("KrvnaGrupa");
                });

            modelBuilder.Entity("eKlinika.Models.LabPretraga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<int>("Id");

                    b.Property<string>("Certifikati");

                    b.Property<string>("Kursevi");

                    b.HasKey("Id");

                    b.ToTable("MedicinskaSestra");
                });

            modelBuilder.Entity("eKlinika.Models.Modalitet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DatumIsporuke");

                    b.Property<DateTime>("DatumNarudzbe");

                    b.Property<int>("DobavljacId");

                    b.HasKey("Id");

                    b.HasIndex("DobavljacId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("eKlinika.Models.NarudzbaStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<int>("Id");

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
                    b.Property<int>("Id");

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumPregleda");

                    b.Property<DateTime>("DatumRezervacije");

                    b.Property<int>("DoktorId");

                    b.Property<int>("MedicinskaSestraId");

                    b.Property<string>("Napomena");

                    b.Property<int>("PacijentId");

                    b.Property<string>("Prioritet");

                    b.Property<string>("TipPregleda");

                    b.Property<bool>("isOdrzan");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("MedicinskaSestraId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Pregled");
                });

            modelBuilder.Entity("eKlinika.Models.Proizvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kontakt");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Proizvodjac");
                });

            modelBuilder.Entity("eKlinika.Models.RacunStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumIzdavanja");

                    b.Property<bool>("IsObradjen");

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("eKlinika.Models.Uloge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("eKlinika.Models.Uplata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojUplatnice");

                    b.Property<DateTime>("DatumUplate");

                    b.Property<double>("Iznos");

                    b.Property<string>("Namjena");

                    b.Property<int>("PacijentId");

                    b.Property<int?>("PregledId");

                    b.Property<string>("ZiroRacun");

                    b.HasKey("Id");

                    b.HasIndex("PacijentId");

                    b.HasIndex("PregledId");

                    b.ToTable("Uplata");
                });

            modelBuilder.Entity("eKlinika.Models.Uputnica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRezultata");

                    b.Property<DateTime>("DatumUputnice");

                    b.Property<bool>("IsGotovNalaz");

                    b.Property<int>("LaboratorijDoktorId");

                    b.Property<int>("PacijentId");

                    b.Property<int>("UputioDoktorId");

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("VrstaPretrage");
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
                        .HasForeignKey("ApotekarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.AutorizacijskiToken", b =>
                {
                    b.HasOne("eKlinika.Models.Korisnici", "Korisnici")
                        .WithMany()
                        .HasForeignKey("KorisniciId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("eKlinika.Models.Korisnici", b =>
                {
                    b.HasOne("eKlinika.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId");
                });

            modelBuilder.Entity("eKlinika.Models.KorisniciUloge", b =>
                {
                    b.HasOne("eKlinika.Models.Korisnici", "Korisnik")
                        .WithMany("KorisniciUloge")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Uloge", "Uloga")
                        .WithMany("KorisniciUloge")
                        .HasForeignKey("UlogaId")
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
                        .WithOne("Osoblje")
                        .HasForeignKey("eKlinika.Models.Osoblje", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eKlinika.Models.Pacijent", b =>
                {
                    b.HasOne("eKlinika.Models.Korisnici", "Korisnici")
                        .WithOne("Pacijent")
                        .HasForeignKey("eKlinika.Models.Pacijent", "Id")
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
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.MedicinskaSestra", "MedicinskaSestra")
                        .WithMany()
                        .HasForeignKey("MedicinskaSestraId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Pregled", "Pregled")
                        .WithMany("Uplata")
                        .HasForeignKey("PregledId");
                });

            modelBuilder.Entity("eKlinika.Models.Uputnica", b =>
                {
                    b.HasOne("eKlinika.Models.Doktor", "LaboratorijDoktor")
                        .WithMany()
                        .HasForeignKey("LaboratorijDoktorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eKlinika.Models.Doktor", "UputioDoktor")
                        .WithMany()
                        .HasForeignKey("UputioDoktorId")
                        .OnDelete(DeleteBehavior.Cascade);

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
#pragma warning restore 612, 618
        }
    }
}

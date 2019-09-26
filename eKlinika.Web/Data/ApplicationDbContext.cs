using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eKlinika.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<RezultatPretrage>().HasOne(x => x.Uputnica)
                .WithMany().OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Apotekar> Apotekar { get; set; }
        public DbSet<ApotekaRacun> ApotekaRacun { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
        public DbSet<Dijagnoza> Dijagnoza { get; set; }
        public DbSet<Dobavljac> Dobavljac { get; set; }
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<KorisniciUloge> KorisniciUloge { get; set; }
        public DbSet<KrvnaGrupa> KrvnaGrupa { get; set; }
        public DbSet<LabPretraga> LabPretraga { get; set; }
        public DbSet<Lijek> Lijek { get; set; }
        public DbSet<Korisnici> Korisnici { get; set; }
        public DbSet<MedicinskaSestra> MedicinskaSestra { get; set; }
        public DbSet<Modalitet> Modalitet { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<NarudzbaStavka> NarudzbaStavka { get; set; }
        public DbSet<Osoblje> Osoblje { get; set; }
        public DbSet<Pacijent> Pacijent { get; set; }
        public DbSet<Pregled> Pregled { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }
        public DbSet<RacunStavka> RacunStavka { get; set; }
        public DbSet<Recept> Recept { get; set; }
        public DbSet<RezultatPretrage> RezultatPretrage { get; set; }
        public DbSet<Uloge> Uloge { get; set; }
        public DbSet<Uplata> Uplata { get; set; }
        public DbSet<Uputnica> Uputnica { get; set; }
        public DbSet<UstanovljenaDijagnoza> UstanovljenaDijagnoza { get; set; }
        public DbSet<VrstaPretrage> VrstaPretrage { get; set; }

        
        
        
    }
}

using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eKlinika.WebAPI.Database
{
    public partial class eKlinikaContext : DbContext
    {
        public eKlinikaContext()
        {
        }

        public eKlinikaContext(DbContextOptions<eKlinikaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apotekar> Apotekar { get; set; }
        public virtual DbSet<ApotekaRacun> ApotekaRacun { get; set; }
        public virtual DbSet<Dijagnoza> Dijagnoza { get; set; }
        public virtual DbSet<Dobavljac> Dobavljac { get; set; }
        public virtual DbSet<Doktor> Doktor { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual DbSet<KrvnaGrupa> KrvnaGrupa { get; set; }
        public virtual DbSet<LabPretraga> LabPretraga { get; set; }
        public virtual DbSet<Lijek> Lijek { get; set; }
        public virtual DbSet<MedicinskaSestra> MedicinskaSestra { get; set; }
        public virtual DbSet<Modalitet> Modalitet { get; set; }
        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<NarudzbaStavka> NarudzbaStavka { get; set; }
        public virtual DbSet<Osoblje> Osoblje { get; set; }
        public virtual DbSet<Pacijent> Pacijent { get; set; }
        public virtual DbSet<Pregled> Pregled { get; set; }
        public virtual DbSet<Proizvodjac> Proizvodjac { get; set; }
        public virtual DbSet<RacunStavka> RacunStavka { get; set; }
        public virtual DbSet<Recept> Recept { get; set; }
        public virtual DbSet<RezultatPretrage> RezultatPretrage { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<Uplata> Uplata { get; set; }
        public virtual DbSet<Uputnica> Uputnica { get; set; }
        public virtual DbSet<UstanovljenaDijagnoza> UstanovljenaDijagnoza { get; set; }
        public virtual DbSet<VrstaPretrage> VrstaPretrage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=eKlinika;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apotekar>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Osoblje)
                    .WithOne(p => p.Apotekar)
                    .HasForeignKey<Apotekar>(d => d.Id);
            });

            modelBuilder.Entity<ApotekaRacun>(entity =>
            {
                entity.HasOne(d => d.Apotekar)
                    .WithMany(p => p.ApotekaRacun)
                    .HasForeignKey(d => d.ApotekarId);

                entity.HasOne(d => d.Pacijent)
                    .WithMany(p => p.ApotekaRacun)
                    .HasForeignKey(d => d.PacijentId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Dobavljac>(entity =>
            {
                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Dobavljac)
                    .HasForeignKey(d => d.DrzavaId);
            });

            modelBuilder.Entity<Doktor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Osoblje)
                    .WithOne(p => p.Doktor)
                    .HasForeignKey<Doktor>(d => d.Id);
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grad)
                    .HasForeignKey(d => d.DrzavaId);
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {

                entity.HasIndex(e => e.Email)
                    .HasName("CS_Email")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("CS_UserName")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Korisnici)
                    .HasForeignKey(d => d.GradId);
            });


            modelBuilder.Entity<LabPretraga>(entity =>
            {
                entity.HasOne(d => d.VrstaPretrage)
                    .WithMany(p => p.LabPretraga)
                    .HasForeignKey(d => d.VrstaPretrageId);
            });

            modelBuilder.Entity<Lijek>(entity =>
            {
                entity.HasOne(d => d.Proizvodjac)
                    .WithMany(p => p.Lijek)
                    .HasForeignKey(d => d.ProizvodjacId);
            });

            modelBuilder.Entity<MedicinskaSestra>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Osoblje)
                    .WithOne(p => p.MedicinskaSestra)
                    .HasForeignKey<MedicinskaSestra>(d => d.Id);
            });

            modelBuilder.Entity<Modalitet>(entity =>
            {
                entity.Property(e => e.IsReferentnaVrijednost).HasColumnName("isReferentnaVrijednost");

                entity.HasOne(d => d.LabPretraga)
                    .WithMany(p => p.Modalitet)
                    .HasForeignKey(d => d.LabPretragaId);
            });

            modelBuilder.Entity<Narudzba>(entity =>
            {
                entity.HasOne(d => d.Dobavljac)
                    .WithMany(p => p.Narudzba)
                    .HasForeignKey(d => d.DobavljacId);
            });

            modelBuilder.Entity<NarudzbaStavka>(entity =>
            {
                entity.HasOne(d => d.Lijek)
                    .WithMany(p => p.NarudzbaStavka)
                    .HasForeignKey(d => d.LijekId);

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.NarudzbaStavka)
                    .HasForeignKey(d => d.NarudzbaId);
            });

            modelBuilder.Entity<Osoblje>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Korisnik)
                    .WithOne(p => p.Osoblje)
                    .HasForeignKey<Osoblje>(d => d.Id);
            });

            modelBuilder.Entity<Pacijent>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Korisnik)
                    .WithOne(p => p.Pacijent)
                    .HasForeignKey<Pacijent>(d => d.Id);

                entity.HasOne(d => d.KrvnaGrupa)
                    .WithMany(p => p.Pacijent)
                    .HasForeignKey(d => d.KrvnaGrupaId);
            });

            modelBuilder.Entity<Pregled>(entity =>
            {
                entity.Property(e => e.IsOdrzan).HasColumnName("isOdrzan");

                entity.HasOne(d => d.Doktor)
                    .WithMany(p => p.Pregled)
                    .HasForeignKey(d => d.DoktorId);

                entity.HasOne(d => d.MedicinskaSestra)
                    .WithMany(p => p.Pregled)
                    .HasForeignKey(d => d.MedicinskaSestraId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Pacijent)
                    .WithMany(p => p.Pregled)
                    .HasForeignKey(d => d.PacijentId)
                    .OnDelete(DeleteBehavior.Restrict);


                entity.HasMany(d => d.Uplata)
                    .WithOne(p => p.Pregled)
                    .HasForeignKey(d => d.PregledId);

            });

            modelBuilder.Entity<RacunStavka>(entity =>
            {
                entity.HasOne(d => d.ApotekaRacun)
                    .WithMany(p => p.RacunStavka)
                    .HasForeignKey(d => d.ApotekaRacunId);

                entity.HasOne(d => d.Lijek)
                    .WithMany(p => p.RacunStavka)
                    .HasForeignKey(d => d.LijekId);
            });

            modelBuilder.Entity<Recept>(entity =>
            {
                entity.HasOne(d => d.Lijek)
                    .WithMany(p => p.Recept)
                    .HasForeignKey(d => d.LijekId);

                entity.HasOne(d => d.Pregled)
                    .WithMany(p => p.Recept)
                    .HasForeignKey(d => d.PregledId);
            });

            modelBuilder.Entity<RezultatPretrage>(entity =>
            {
                entity.HasOne(d => d.LabPretraga)
                    .WithMany(p => p.RezultatPretrage)
                    .HasForeignKey(d => d.LabPretragaId);

                entity.HasOne(d => d.Modalitet)
                    .WithMany(p => p.RezultatPretrage)
                    .HasForeignKey(d => d.ModalitetId);

                entity.HasOne(d => d.Uputnica)
                    .WithMany(p => p.RezultatPretrage)
                    .HasForeignKey(d => d.UputnicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Uplata>(entity =>
            {
                entity.HasOne(d => d.Pacijent)
                    .WithMany(p => p.Uplata)
                    .HasForeignKey(d => d.PacijentId);

                entity.HasOne(d => d.Pregled)
                    .WithMany(p => p.Uplata)
                    .HasForeignKey(d => d.PregledId);


            });

            modelBuilder.Entity<Uputnica>(entity =>
            {
                entity.HasOne(d => d.Pacijent)
                    .WithMany(p => p.Uputnica)
                    .HasForeignKey(d => d.PacijentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.VrstaPretrage)
                    .WithMany(p => p.Uputnica)
                    .HasForeignKey(d => d.VrstaPretrageId);
                
                entity.HasOne(d => d.UputioDoktor)
                    .WithMany()
                    .HasForeignKey(d => d.UputioDoktorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.LaboratorijDoktor)
                    .WithMany()
                    .HasForeignKey(d => d.LaboratorijDoktorId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<UstanovljenaDijagnoza>(entity =>
            {
                entity.HasOne(d => d.Dijagnoza)
                    .WithMany(p => p.UstanovljenaDijagnoza)
                    .HasForeignKey(d => d.DijagnozaId);

                entity.HasOne(d => d.Pregled)
                    .WithMany(p => p.UstanovljenaDijagnoza)
                    .HasForeignKey(d => d.PregledId);
            });
        }
    }
}

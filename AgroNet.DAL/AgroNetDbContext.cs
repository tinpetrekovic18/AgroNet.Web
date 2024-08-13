using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using AgroNet.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace AgroNet.DAL
{
    public class AgroNetDbContext : IdentityDbContext<AppUser>
    {
        protected AgroNetDbContext() { }
        public AgroNetDbContext(DbContextOptions<AgroNetDbContext> options) : base(options)
        { }

        public DbSet<Imanje> Imanja { get; set; }
        public DbSet<Zupanija> Zupanije { get; set; }
        public DbSet<Mjesto> Mjesta { get; set; }
        public DbSet<Vlasnik> Vlasnici { get; set; }
        public DbSet<OPG> OPGs { get; set; }
        public DbSet<VrstaProizvoda> VrsteProizvoda { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<VrstaUsluge> VrsteUsluga { get; set; }
        public DbSet<Usluga> Usluge { get; set; }
        public DbSet<VrstaStrojaAlata> VrsteStrojevaAlata { get; set; }
        public DbSet<StrojAlat> StrojeviAlati { get; set; }
        public DbSet<Djelatnost> Djelatnosti { get; set; }
        public DbSet<StatusNarudzbe> StatusiNarudzbi { get; set; }
        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<StavkaNarudzbeProizvod> StavkeNarudzbeProizvoda { get; set; }
        public DbSet<StavkaNarudzbeUsluga> StavkeNarudzbeUsluga { get; set; }
        public DbSet<VlasnikOPG> VlasniciOPG { get; set; }
        public DbSet<ImanjeVlasnik> ImanjaVlasnici { get; set; }
        public DbSet<OPGProizvod> OPGProizvodi { get; set; }
        public DbSet<OPGUsluga> OPGUsluge { get; set; }
        public DbSet<OPGStrojeviAlati> OPGStrojeviAlati { get; set; }
        public DbSet<DjelatnostiOPG> DjelatnostiOPG { get; set; }
        public DbSet<AppUser> Korisnici { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Narudzba>()
                .HasOne(n => n.KupacOPG)
                .WithMany()
                .HasForeignKey(n => n.KupacOPGId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Narudzba>()
                .HasOne(n => n.ProdavacOPG)
                .WithMany()
                .HasForeignKey(n => n.ProdavacOPGId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<VlasnikOPG>()
                .HasOne(vo => vo.Vlasnik)
                .WithMany()
                .HasForeignKey(vo => vo.VlasnikId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<VlasnikOPG>()
                .HasOne(vo => vo.OPG)
                .WithMany()
                .HasForeignKey(vo => vo.OPGId)
                .OnDelete(DeleteBehavior.NoAction); 

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 1, Naziv = "Zagrebačka županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 2, Naziv = "Krapinsko-zagorska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 3, Naziv = "Sisačko-moslavačka županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 4, Naziv = "Karlovačka županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 5, Naziv = "Varaždinska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 6, Naziv = "Koprivničko-križevačka županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 7, Naziv = "Bjelovarsko-bilogorska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 8, Naziv = "Primorsko-goranska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 9, Naziv = "Ličko-senjska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 10, Naziv = "Virovitičko-podravska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 11, Naziv = "Požeško-slavonska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 12, Naziv = "Brodsko-posavska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 13, Naziv = "Zadarska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 14, Naziv = "Osječko-baranjska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 15, Naziv = "Šibensko-kninska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 16, Naziv = "Vukovarsko-srijemska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 17, Naziv = "Splitsko-dalmatinska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 18, Naziv = "Istarska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 19, Naziv = "Dubrovačko-neretvanska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 20, Naziv = "Međimurska županija" });
            modelBuilder.Entity<Zupanija>().HasData(new Zupanija { Id = 21, Naziv = "Grad Zagreb" });


        }

    }
}

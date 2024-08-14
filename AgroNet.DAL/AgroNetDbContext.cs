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

            
            modelBuilder.Entity<Djelatnost>().HasData(new Djelatnost
            {
                Id = 1,
                Naziv = "PROIZVODNJA POLJOPRIVREDNIH I PREHRAMBENIH PROIZVODA",
                Opis = "1.1.\r\nproizvodnja poljoprivrednih proizvoda od sirovine dijelom iz vlastite proizvodnje uz kupnju do 50%\r\nsirovine drugih poljoprivrednih gospodarstva u dijelu proizvodnje alkoholnih pića i octa, piva do 2.000\r\nhl, vina od grožđa, voćnog vina, likera, rakija, ostalih alkoholna pića i sl.,\r\n1.2.\r\nproizvodnja prehrambenih proizvoda od sirovine dijelom iz vlastite proizvodnje uz kupnju do 50%\r\nsirovine od drugih poljoprivrednih gospodarstva (osim kupnje mlijeka i mesa) radi proizvodnje sirupa,\r\nsokova, ulja, džemova, pekmeza, kruha, kolača, kroštula, tjestenina, arancina,\r\nsušenog/zamrznutog/konzerviranog voća, povrća i sl.,\r\n1.3.\r\npakiranje i/ili zamrzavanje i/ili sušenje i/ili konzerviranje proizvoda od sirovine dijelom iz vlastite\r\nproizvodnje uz kupnju do 50% sirovine drugih poljoprivrednih gospodarstva u dijelu proizvoda od gljiva,\r\nšumskih plodova, samoniklog, uzgojenog i ostalog bilja i sl. .\r\n"
            });
            modelBuilder.Entity<Djelatnost>().HasData(new Djelatnost
            {
                Id = 2,
                Naziv = "IZRADA NEPREHRAMBENIH PROIZVODA I PREDMETA OPĆE UPORABE",
                Opis = "2.1.\r\nizrada proizvoda od drva (drvene motke grubo uobličene, netokarene i drugi proizvodi od drva, drvna\r\nšindru i slično), izrada zaprežnih kola i drugih drvenih poljoprivrednih alata te izrada tradicijskog\r\nnamještaja povezano sa zanimanjima tradicijskih obrta i/ili tradicijskim vještinama;\r\n2.2.\r\nizrada proizvoda od slame i drugih pletarskih materijala (bambus, ratan, trska, rogoz, vrbovo pruće,\r\nrafija, očišćena, bijeljena ili bojena slama žitarica te lipova kora) povezano sa zanimanjima tradicijskih\r\nobrta i/ili tradicijskim vještinama;\r\n2.3. izrada rukotvorina, nakita, igračaka i suvenira od tkanine, kože, kamena, gline, stakla i drugih materijala\r\npovezano sa zanimanjima tradicijskih obrta i/ili tradicijskim vještinama;\r\n2.4. izrada proizvoda od pčelinjeg voska, sapuna, drugih neprehrambenih proizvoda i predmeta opće\r\nupotrebe povezano sa zanimanjima tradicijskih obrta i/ili tradicijskim vještinama;\r\n2.5. izrada eteričnih ulja, kozmetičkih proizvoda i drugih neprehrambenih proizvoda i predmeta opće\r\nupotrebe;\r\n2.6.\r\nizrada proizvoda od konca i vune (pletenje, vezenje, kukičanje, proizvodnja proizvoda od čipke,\r\nproizvoda od filcane vune, izrada tradicijske odjeće i narodnih nošnji) povezano sa zanimanjima\r\ntradicijskih obrta i/ili tradicijskim vještinama;\r\n2.7. izrada proizvoda od svježeg i sušenog cvijeća i drugog bilja povezano sa zanimanjima tradicijskih obrta\r\ni/ili tradicijskim vještinama;\r\n2.8.\r\nizrada ostalih proizvoda od drva (cijepani kolci; drveni kolci i stupovi, zašiljeni ali uzdužno nepiljeni) te\r\nizrada, pakiranje, obrada, prerada ogrjevnog drva u obliku oblica, cjepanica, pruća, snopova ili sličnih\r\noblika (paletirani, briketirani, piletirani);"
            });
            modelBuilder.Entity<Djelatnost>().HasData(new Djelatnost
            {
                Id = 3,
                Naziv = "PRUŽANJE USLUGA",
                Opis = "3.1.\r\npružanje usluga s poljoprivrednom i šumskom mehanizacijom opremom, uređajima i/ili alatima koje\r\nobuhvaćaju rad s traktorima i drugim poljoprivrednim strojevima u komunalnim poslovima (zimsko\r\nodržavanje cesta i putova, čišćenje, košnja i održavanje zelenila i zelenih površina);\r\n3.2. pružanje usluga s poljoprivrednom i šumskom mehanizacijom, opremom, uređajima i/ili alatima u\r\ngrađevinskim poslovima (iskop, ravnanje, dovoz, odvoz i slično);\r\n3.3.\r\nusluge u šumarstvu s poljoprivrednom i šumskom mehanizacijom, opremom, uređajima opremom,\r\nuređajima i/ili alatima koje obuhvaćaju sječu drva, izvlačenje drva iz šume, izradu trupaca, drvne sječke,\r\npiljenje drva i slično; 3.4.\r\nusluge s radnim životinjama u poljoprivrednim i šumsko-gospodarskim poslovima koje obuhvaćaju\r\nprijenos, prijevoz poljoprivrednih proizvoda i obavljanje poljoprivrednih poslova sa životinjama,\r\niznošenje i izvlačenje drva iz šume sa životinjama i slično;\r\n3.5.\r\nusluge s radnim životinjama u ostalim aktivnostima, (vožnja kočijom, jahanje i obuka u jahanju,\r\nterapijsko jahanje, obuka, treniranje i/ili korištenje radnih životinja (konja, pasa i drugih) i slično\r\npovezano s ruralnim običajima i/ili tradicijskim vještinama;\r\n3.6.\r\nostale usluge, aktivnosti i savjeti vezani uz držanje životinja, uzgoj bilja i preradu poljoprivrednih\r\nproizvoda (striža/šišanje ovaca, cijepljenje i orezivanje voćki i vinove loze, zbrinjavanje rojeva pčela,\r\nuklanjanje osa, biodinamički uzgoj povrtnog bilja i slično);\r\n3.7.\r\nostale usluge i aktivnosti u korištenju raspoloživih radnih resursa gospodarstva (uslužni prijevoz mlijeka,\r\nprijevoz poljoprivrednih proizvoda, prijevoz životinja, održavanje grobova, uslužna dorada i/ili pakiranje\r\ni/ili skladištenje poljoprivrednih i/ili prehrambenih proizvoda i slično)"
            });
            modelBuilder.Entity<Djelatnost>().HasData(new Djelatnost
            {
                Id = 4,
                Naziv = "PRUŽANJE TURISTIČKIH I UGOSTITELJSKIH USLUGA",
                Opis = "4.1. pružanje ugostiteljskih usluga u objektima koji mogu biti: vinotočje/kušaonice, izletište, sobe,\r\napartmani, ruralne kuće za odmor, kamp;\r\n4.2.\r\npružanje turističkih usluga koje mogu biti: omogućavanje sudjelovanja u poljoprivrednim aktivnostima\r\nkao što su berba voća i povrća, ubiranje ljetine i sl., lov i ribolov, vožnja kočijom, čamcem, biciklom,\r\njahanje, pješačenje i slične aktivnosti te iznajmljivanje sredstava, pribora i opreme za te aktivnosti;\r\nprovođenje programa kreativnih i edukativnih radionica vezanih uz poljoprivredu, tradicijske obrte i sl.,\r\nprezentacija poljoprivrednoga gospodarstva te prirodnih i kulturnih vrijednosti u okviru istog, posjete\r\nregistriranim privatnim etno zbirkama i sl. organizacija izleta za goste koji koriste usluge smještaja;\r\nomogućavanje prostora za piknik i izlet; omogućavanje korištenja žičare, vučnice, uspinjače i sl.,;\r\n"
            });
            modelBuilder.Entity<Djelatnost>().HasData(new Djelatnost
            {
                Id = 5,
                Naziv = "PRUŽANJE OSTALIH SADRŽAJA I AKTIVNOSTI",
                Opis = "5.1. omogućavanje stjecanja znanja i vještina o uzgoju bilja i životinja;\r\n5.2. omogućavanje organiziranja tečajeva za izradu tradicijskih proizvoda i rukotvorina;\r\n5.3. omogućavanje edukacijskih praktikuma i/ili omogućavanje održavanja radionica, tečajeva, seminara i\r\nedukacija iz registrirane dopunske djelatnosti OPG-a;\r\n5.4\r\nproizvodnja i isporuka energije iz obnovljivih izvora od poljoprivredne i/ili šumske biomase, stajskog\r\ngnoja, gnojovke, gnojnice, drugih izvora biomase, vode, vjetra i sunca do snage 1MW nominalne snage\r\ngeneratora (kotla);\r\n5.5 proizvodnja i isporuka organskih gnojiva (humusa, glisnjaka i drugih) proizvedenih na OPG-u;\r\n5.6. uzgoj i isporuka divljači, uzgoj rakova, žaba, slatkovodni uzgoj riba – aquakultura na OPG-u;\r\n5.7. uzgoj ostalih nespomenutih biljnih vrsta (drveća, grmlja, cvijeća, božićnih drvaca i ukrasnog bilja) na\r\nOPG-u;\r\n5.8. sudjelovanje na manifestacijama prikazivanjem aktivnosti i djelatnosti OPG-a vezanih s ruralnim\r\nobičajima, zanimanjima tradicijskih obrta i/ili tradicijskim vještinama;\r\n5.9. sakupljanje samoniklog bilja (aromatičnog, začinskog i dr.), gljiva, šumskih plodova (borovnica, šipka,\r\nkupina, kestena, žira i dr.) i ostalog bilja"
            });

            modelBuilder.Entity<StatusNarudzbe>().HasData(new StatusNarudzbe { Id = 1, Naziv = "U obradi", Opis= "Narudžba je podnesena. Čeka se vlasnik da potvrdi narudžbu." });
            modelBuilder.Entity<StatusNarudzbe>().HasData(new StatusNarudzbe { Id = 2, Naziv = "Potvrđeno", Opis = "Narudžba je potvrđena. Vlasnik će uskoro izvržiti narudžbu." });
            modelBuilder.Entity<StatusNarudzbe>().HasData(new StatusNarudzbe { Id = 3, Naziv = "Izvršava se", Opis = "Narudžba se trenutno izvršava." });
            modelBuilder.Entity<StatusNarudzbe>().HasData(new StatusNarudzbe { Id = 4, Naziv = "Završeno", Opis = "Narudžba je u cijelosti završena." });
            modelBuilder.Entity<StatusNarudzbe>().HasData(new StatusNarudzbe { Id = 5, Naziv = "Odbijeno", Opis = "Vlasnik je odbio narudžbu." });
            modelBuilder.Entity<StatusNarudzbe>().HasData(new StatusNarudzbe { Id = 6, Naziv = "Otkazano", Opis = "Narudžba je otkazana." });

            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 1, Naziv = "Meso i mesne prerađevine" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 2, Naziv = "Riba, morski plodovi i mekušci" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 3, Naziv = "Povrće" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 4, Naziv = "Voće" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 5, Naziv = "Žitarice" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 6, Naziv = "Stoka" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 7, Naziv = "Perad" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 8, Naziv = "Orašasti plodovi" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 9, Naziv = "Mlijeko i mlječni prozivodi" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 10, Naziv = "Ulja i masti" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 11, Naziv = "Sjeme i sadnice" });
            modelBuilder.Entity<VrstaProizvoda>().HasData(new VrstaProizvoda { Id = 12, Naziv = "Ostalo" });

            modelBuilder.Entity<VrstaUsluge>().HasData(new VrstaUsluge { Id = 1, Naziv = "Poljoprivredna mehanizacija i oprema" });
            modelBuilder.Entity<VrstaUsluge>().HasData(new VrstaUsluge { Id = 2, Naziv = "Ugostiteljske i turističke usluge" });
            modelBuilder.Entity<VrstaUsluge>().HasData(new VrstaUsluge { Id = 3, Naziv = "Šumska mehanizacija i oprema" });
            modelBuilder.Entity<VrstaUsluge>().HasData(new VrstaUsluge { Id = 4, Naziv = "Građevinska mehanizacija i oprema" });
            modelBuilder.Entity<VrstaUsluge>().HasData(new VrstaUsluge { Id = 5, Naziv = "Usluge s radnim životinjama" });
            modelBuilder.Entity<VrstaUsluge>().HasData(new VrstaUsluge { Id = 6, Naziv = "Aktivnost i savjetovanje" });
            modelBuilder.Entity<VrstaUsluge>().HasData(new VrstaUsluge { Id = 7, Naziv = "Ostalo" });

            modelBuilder.Entity<VrstaStrojaAlata>().HasData(new VrstaStrojaAlata { Id = 1, Naziv = "Traktor" });
            modelBuilder.Entity<VrstaStrojaAlata>().HasData(new VrstaStrojaAlata { Id = 2, Naziv = "Kombajn" });
            modelBuilder.Entity<VrstaStrojaAlata>().HasData(new VrstaStrojaAlata { Id = 3, Naziv = "Sjetva, žetva i berba" });
            modelBuilder.Entity<VrstaStrojaAlata>().HasData(new VrstaStrojaAlata { Id = 4, Naziv = "Obrada tla" });
            modelBuilder.Entity<VrstaStrojaAlata>().HasData(new VrstaStrojaAlata { Id = 5, Naziv = "Zaštita, gnojidba, navodnjavanje" });
            modelBuilder.Entity<VrstaStrojaAlata>().HasData(new VrstaStrojaAlata { Id = 6, Naziv = "Transport i pretovar" });


        }

    }
}

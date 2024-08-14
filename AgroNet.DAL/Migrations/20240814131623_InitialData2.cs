using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroNet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialData2 : Migration
    {
        /// <inheritdoc />0
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Djelatnosti",
                columns: new[] { "Id", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "PROIZVODNJA POLJOPRIVREDNIH I PREHRAMBENIH PROIZVODA", "1.1.\r\nproizvodnja poljoprivrednih proizvoda od sirovine dijelom iz vlastite proizvodnje uz kupnju do 50%\r\nsirovine drugih poljoprivrednih gospodarstva u dijelu proizvodnje alkoholnih pića i octa, piva do 2.000\r\nhl, vina od grožđa, voćnog vina, likera, rakija, ostalih alkoholna pića i sl.,\r\n1.2.\r\nproizvodnja prehrambenih proizvoda od sirovine dijelom iz vlastite proizvodnje uz kupnju do 50%\r\nsirovine od drugih poljoprivrednih gospodarstva (osim kupnje mlijeka i mesa) radi proizvodnje sirupa,\r\nsokova, ulja, džemova, pekmeza, kruha, kolača, kroštula, tjestenina, arancina,\r\nsušenog/zamrznutog/konzerviranog voća, povrća i sl.,\r\n1.3.\r\npakiranje i/ili zamrzavanje i/ili sušenje i/ili konzerviranje proizvoda od sirovine dijelom iz vlastite\r\nproizvodnje uz kupnju do 50% sirovine drugih poljoprivrednih gospodarstva u dijelu proizvoda od gljiva,\r\nšumskih plodova, samoniklog, uzgojenog i ostalog bilja i sl. .\r\n" },
                    { 2, "IZRADA NEPREHRAMBENIH PROIZVODA I PREDMETA OPĆE UPORABE", "2.1.\r\nizrada proizvoda od drva (drvene motke grubo uobličene, netokarene i drugi proizvodi od drva, drvna\r\nšindru i slično), izrada zaprežnih kola i drugih drvenih poljoprivrednih alata te izrada tradicijskog\r\nnamještaja povezano sa zanimanjima tradicijskih obrta i/ili tradicijskim vještinama;\r\n2.2.\r\nizrada proizvoda od slame i drugih pletarskih materijala (bambus, ratan, trska, rogoz, vrbovo pruće,\r\nrafija, očišćena, bijeljena ili bojena slama žitarica te lipova kora) povezano sa zanimanjima tradicijskih\r\nobrta i/ili tradicijskim vještinama;\r\n2.3. izrada rukotvorina, nakita, igračaka i suvenira od tkanine, kože, kamena, gline, stakla i drugih materijala\r\npovezano sa zanimanjima tradicijskih obrta i/ili tradicijskim vještinama;\r\n2.4. izrada proizvoda od pčelinjeg voska, sapuna, drugih neprehrambenih proizvoda i predmeta opće\r\nupotrebe povezano sa zanimanjima tradicijskih obrta i/ili tradicijskim vještinama;\r\n2.5. izrada eteričnih ulja, kozmetičkih proizvoda i drugih neprehrambenih proizvoda i predmeta opće\r\nupotrebe;\r\n2.6.\r\nizrada proizvoda od konca i vune (pletenje, vezenje, kukičanje, proizvodnja proizvoda od čipke,\r\nproizvoda od filcane vune, izrada tradicijske odjeće i narodnih nošnji) povezano sa zanimanjima\r\ntradicijskih obrta i/ili tradicijskim vještinama;\r\n2.7. izrada proizvoda od svježeg i sušenog cvijeća i drugog bilja povezano sa zanimanjima tradicijskih obrta\r\ni/ili tradicijskim vještinama;\r\n2.8.\r\nizrada ostalih proizvoda od drva (cijepani kolci; drveni kolci i stupovi, zašiljeni ali uzdužno nepiljeni) te\r\nizrada, pakiranje, obrada, prerada ogrjevnog drva u obliku oblica, cjepanica, pruća, snopova ili sličnih\r\noblika (paletirani, briketirani, piletirani);" },
                    { 3, "PRUŽANJE USLUGA", "3.1.\r\npružanje usluga s poljoprivrednom i šumskom mehanizacijom opremom, uređajima i/ili alatima koje\r\nobuhvaćaju rad s traktorima i drugim poljoprivrednim strojevima u komunalnim poslovima (zimsko\r\nodržavanje cesta i putova, čišćenje, košnja i održavanje zelenila i zelenih površina);\r\n3.2. pružanje usluga s poljoprivrednom i šumskom mehanizacijom, opremom, uređajima i/ili alatima u\r\ngrađevinskim poslovima (iskop, ravnanje, dovoz, odvoz i slično);\r\n3.3.\r\nusluge u šumarstvu s poljoprivrednom i šumskom mehanizacijom, opremom, uređajima opremom,\r\nuređajima i/ili alatima koje obuhvaćaju sječu drva, izvlačenje drva iz šume, izradu trupaca, drvne sječke,\r\npiljenje drva i slično; 3.4.\r\nusluge s radnim životinjama u poljoprivrednim i šumsko-gospodarskim poslovima koje obuhvaćaju\r\nprijenos, prijevoz poljoprivrednih proizvoda i obavljanje poljoprivrednih poslova sa životinjama,\r\niznošenje i izvlačenje drva iz šume sa životinjama i slično;\r\n3.5.\r\nusluge s radnim životinjama u ostalim aktivnostima, (vožnja kočijom, jahanje i obuka u jahanju,\r\nterapijsko jahanje, obuka, treniranje i/ili korištenje radnih životinja (konja, pasa i drugih) i slično\r\npovezano s ruralnim običajima i/ili tradicijskim vještinama;\r\n3.6.\r\nostale usluge, aktivnosti i savjeti vezani uz držanje životinja, uzgoj bilja i preradu poljoprivrednih\r\nproizvoda (striža/šišanje ovaca, cijepljenje i orezivanje voćki i vinove loze, zbrinjavanje rojeva pčela,\r\nuklanjanje osa, biodinamički uzgoj povrtnog bilja i slično);\r\n3.7.\r\nostale usluge i aktivnosti u korištenju raspoloživih radnih resursa gospodarstva (uslužni prijevoz mlijeka,\r\nprijevoz poljoprivrednih proizvoda, prijevoz životinja, održavanje grobova, uslužna dorada i/ili pakiranje\r\ni/ili skladištenje poljoprivrednih i/ili prehrambenih proizvoda i slično)" },
                    { 4, "PRUŽANJE TURISTIČKIH I UGOSTITELJSKIH USLUGA", "4.1. pružanje ugostiteljskih usluga u objektima koji mogu biti: vinotočje/kušaonice, izletište, sobe,\r\napartmani, ruralne kuće za odmor, kamp;\r\n4.2.\r\npružanje turističkih usluga koje mogu biti: omogućavanje sudjelovanja u poljoprivrednim aktivnostima\r\nkao što su berba voća i povrća, ubiranje ljetine i sl., lov i ribolov, vožnja kočijom, čamcem, biciklom,\r\njahanje, pješačenje i slične aktivnosti te iznajmljivanje sredstava, pribora i opreme za te aktivnosti;\r\nprovođenje programa kreativnih i edukativnih radionica vezanih uz poljoprivredu, tradicijske obrte i sl.,\r\nprezentacija poljoprivrednoga gospodarstva te prirodnih i kulturnih vrijednosti u okviru istog, posjete\r\nregistriranim privatnim etno zbirkama i sl. organizacija izleta za goste koji koriste usluge smještaja;\r\nomogućavanje prostora za piknik i izlet; omogućavanje korištenja žičare, vučnice, uspinjače i sl.,;\r\n" },
                    { 5, "PRUŽANJE OSTALIH SADRŽAJA I AKTIVNOSTI", "5.1. omogućavanje stjecanja znanja i vještina o uzgoju bilja i životinja;\r\n5.2. omogućavanje organiziranja tečajeva za izradu tradicijskih proizvoda i rukotvorina;\r\n5.3. omogućavanje edukacijskih praktikuma i/ili omogućavanje održavanja radionica, tečajeva, seminara i\r\nedukacija iz registrirane dopunske djelatnosti OPG-a;\r\n5.4\r\nproizvodnja i isporuka energije iz obnovljivih izvora od poljoprivredne i/ili šumske biomase, stajskog\r\ngnoja, gnojovke, gnojnice, drugih izvora biomase, vode, vjetra i sunca do snage 1MW nominalne snage\r\ngeneratora (kotla);\r\n5.5 proizvodnja i isporuka organskih gnojiva (humusa, glisnjaka i drugih) proizvedenih na OPG-u;\r\n5.6. uzgoj i isporuka divljači, uzgoj rakova, žaba, slatkovodni uzgoj riba – aquakultura na OPG-u;\r\n5.7. uzgoj ostalih nespomenutih biljnih vrsta (drveća, grmlja, cvijeća, božićnih drvaca i ukrasnog bilja) na\r\nOPG-u;\r\n5.8. sudjelovanje na manifestacijama prikazivanjem aktivnosti i djelatnosti OPG-a vezanih s ruralnim\r\nobičajima, zanimanjima tradicijskih obrta i/ili tradicijskim vještinama;\r\n5.9. sakupljanje samoniklog bilja (aromatičnog, začinskog i dr.), gljiva, šumskih plodova (borovnica, šipka,\r\nkupina, kestena, žira i dr.) i ostalog bilja" }
                });

            migrationBuilder.InsertData(
                table: "StatusiNarudzbi",
                columns: new[] { "Id", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "U obradi", "Narudžba je podnesena. Čeka se vlasnik da potvrdi narudžbu." },
                    { 2, "Potvrđeno", "Narudžba je potvrđena. Vlasnik će uskoro izvržiti narudžbu." },
                    { 3, "Izvršava se", "Narudžba se trenutno izvršava." },
                    { 4, "Završeno", "Narudžba je u cijelosti završena." },
                    { 5, "Odbijeno", "Vlasnik je odbio narudžbu." },
                    { 6, "Otkazano", "Narudžba je otkazana." }
                });

            migrationBuilder.InsertData(
                table: "VrsteProizvoda",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Meso i mesne prerađevine" },
                    { 2, "Riba, morski plodovi i mekušci" },
                    { 3, "Povrće" },
                    { 4, "Voće" },
                    { 5, "Žitarice" },
                    { 6, "Stoka" },
                    { 7, "Perad" },
                    { 8, "Orašasti plodovi" },
                    { 9, "Mlijeko i mlječni prozivodi" },
                    { 10, "Ulja i masti" },
                    { 11, "Sjeme i sadnice" },
                    { 12, "Ostalo" }
                });

            migrationBuilder.InsertData(
                table: "VrsteStrojevaAlata",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Traktor" },
                    { 2, "Kombajn" },
                    { 3, "Sjetva, žetva i berba" },
                    { 4, "Obrada tla" },
                    { 5, "Zaštita, gnojidba, navodnjavanje" },
                    { 6, "Transport i pretovar" }
                });

            migrationBuilder.InsertData(
                table: "VrsteUsluga",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Poljoprivredna mehanizacija i oprema" },
                    { 2, "Ugostiteljske i turističke usluge" },
                    { 3, "Šumska mehanizacija i oprema" },
                    { 4, "Građevinska mehanizacija i oprema" },
                    { 5, "Usluge s radnim životinjama" },
                    { 6, "Aktivnost i savjetovanje" },
                    { 7, "Ostalo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Djelatnosti",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Djelatnosti",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Djelatnosti",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Djelatnosti",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Djelatnosti",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StatusiNarudzbi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusiNarudzbi",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusiNarudzbi",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StatusiNarudzbi",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StatusiNarudzbi",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StatusiNarudzbi",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "VrsteStrojevaAlata",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VrsteStrojevaAlata",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VrsteStrojevaAlata",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VrsteStrojevaAlata",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VrsteStrojevaAlata",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VrsteStrojevaAlata",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VrsteUsluga",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VrsteUsluga",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VrsteUsluga",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VrsteUsluga",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VrsteUsluga",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VrsteUsluga",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VrsteUsluga",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}

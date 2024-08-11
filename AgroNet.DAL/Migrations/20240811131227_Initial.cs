using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroNet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Djelatnosti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Djelatnosti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Katastar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Povrsina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imanja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusiNarudzbi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusiNarudzbi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrsteProizvoda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrsteProizvoda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrsteStrojevaAlata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrsteStrojevaAlata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrsteUsluga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrsteUsluga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zupanije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zupanije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaProizvodaId = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proizvodi_VrsteProizvoda_VrstaProizvodaId",
                        column: x => x.VrstaProizvodaId,
                        principalTable: "VrsteProizvoda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrojeviAlati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaStrojaAlataId = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrojeviAlati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrojeviAlati_VrsteStrojevaAlata_VrstaStrojaAlataId",
                        column: x => x.VrstaStrojaAlataId,
                        principalTable: "VrsteStrojevaAlata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrstaUslugeId = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usluge_VrsteUsluga_VrstaUslugeId",
                        column: x => x.VrstaUslugeId,
                        principalTable: "VrsteUsluga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mjesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false),
                    ZupanijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mjesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mjesta_Zupanije_ZupanijaId",
                        column: x => x.ZupanijaId,
                        principalTable: "Zupanije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OPGs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MjestoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPGs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OPGs_Mjesta_MjestoId",
                        column: x => x.MjestoId,
                        principalTable: "Mjesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vlasnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OIB = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    MjestoPrebivalistaId = table.Column<int>(type: "int", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vlasnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vlasnici_Mjesta_MjestoPrebivalistaId",
                        column: x => x.MjestoPrebivalistaId,
                        principalTable: "Mjesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DjelatnostiOPG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OPGId = table.Column<int>(type: "int", nullable: false),
                    DjelatnostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DjelatnostiOPG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DjelatnostiOPG_Djelatnosti_DjelatnostId",
                        column: x => x.DjelatnostId,
                        principalTable: "Djelatnosti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DjelatnostiOPG_OPGs_OPGId",
                        column: x => x.OPGId,
                        principalTable: "OPGs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KupacOPGId = table.Column<int>(type: "int", nullable: false),
                    ProdavacOPGId = table.Column<int>(type: "int", nullable: false),
                    DatumNarudzbe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DatumIsporuke = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusNarudzbeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzbe_OPGs_KupacOPGId",
                        column: x => x.KupacOPGId,
                        principalTable: "OPGs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzbe_OPGs_ProdavacOPGId",
                        column: x => x.ProdavacOPGId,
                        principalTable: "OPGs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Narudzbe_StatusiNarudzbi_StatusNarudzbeId",
                        column: x => x.StatusNarudzbeId,
                        principalTable: "StatusiNarudzbi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OPGProizvodi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OPGId = table.Column<int>(type: "int", nullable: false),
                    ProizvodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPGProizvodi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OPGProizvodi_OPGs_OPGId",
                        column: x => x.OPGId,
                        principalTable: "OPGs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OPGProizvodi_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OPGStrojeviAlati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OPGId = table.Column<int>(type: "int", nullable: false),
                    StrojAlatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPGStrojeviAlati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OPGStrojeviAlati_OPGs_OPGId",
                        column: x => x.OPGId,
                        principalTable: "OPGs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OPGStrojeviAlati_StrojeviAlati_StrojAlatId",
                        column: x => x.StrojAlatId,
                        principalTable: "StrojeviAlati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OPGUsluge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OPGId = table.Column<int>(type: "int", nullable: false),
                    UslugaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPGUsluge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OPGUsluge_OPGs_OPGId",
                        column: x => x.OPGId,
                        principalTable: "OPGs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OPGUsluge_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImanjaVlasnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VlasnikId = table.Column<int>(type: "int", nullable: false),
                    ImanjeId = table.Column<int>(type: "int", nullable: false),
                    ProizvodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImanjaVlasnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImanjaVlasnici_Imanja_ImanjeId",
                        column: x => x.ImanjeId,
                        principalTable: "Imanja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImanjaVlasnici_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImanjaVlasnici_Vlasnici_VlasnikId",
                        column: x => x.VlasnikId,
                        principalTable: "Vlasnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VlasniciOPG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VlasnikId = table.Column<int>(type: "int", nullable: false),
                    OPGId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VlasniciOPG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VlasniciOPG_OPGs_OPGId",
                        column: x => x.OPGId,
                        principalTable: "OPGs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VlasniciOPG_Vlasnici_VlasnikId",
                        column: x => x.VlasnikId,
                        principalTable: "Vlasnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeNarudzbeProizvoda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarudzbaId = table.Column<int>(type: "int", nullable: false),
                    ProizvodId = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: true),
                    JedinicnaCijena = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeNarudzbeProizvoda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbeProizvoda_Narudzbe_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbeProizvoda_Proizvodi_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StavkeNarudzbeUsluga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarudzbaId = table.Column<int>(type: "int", nullable: false),
                    UslugaId = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    JedinicnaCijena = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeNarudzbeUsluga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbeUsluga_Narudzbe_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbeUsluga_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DjelatnostiOPG_DjelatnostId",
                table: "DjelatnostiOPG",
                column: "DjelatnostId");

            migrationBuilder.CreateIndex(
                name: "IX_DjelatnostiOPG_OPGId",
                table: "DjelatnostiOPG",
                column: "OPGId");

            migrationBuilder.CreateIndex(
                name: "IX_ImanjaVlasnici_ImanjeId",
                table: "ImanjaVlasnici",
                column: "ImanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImanjaVlasnici_ProizvodId",
                table: "ImanjaVlasnici",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_ImanjaVlasnici_VlasnikId",
                table: "ImanjaVlasnici",
                column: "VlasnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Mjesta_ZupanijaId",
                table: "Mjesta",
                column: "ZupanijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_KupacOPGId",
                table: "Narudzbe",
                column: "KupacOPGId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_ProdavacOPGId",
                table: "Narudzbe",
                column: "ProdavacOPGId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_StatusNarudzbeId",
                table: "Narudzbe",
                column: "StatusNarudzbeId");

            migrationBuilder.CreateIndex(
                name: "IX_OPGProizvodi_OPGId",
                table: "OPGProizvodi",
                column: "OPGId");

            migrationBuilder.CreateIndex(
                name: "IX_OPGProizvodi_ProizvodId",
                table: "OPGProizvodi",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_OPGs_MjestoId",
                table: "OPGs",
                column: "MjestoId");

            migrationBuilder.CreateIndex(
                name: "IX_OPGStrojeviAlati_OPGId",
                table: "OPGStrojeviAlati",
                column: "OPGId");

            migrationBuilder.CreateIndex(
                name: "IX_OPGStrojeviAlati_StrojAlatId",
                table: "OPGStrojeviAlati",
                column: "StrojAlatId");

            migrationBuilder.CreateIndex(
                name: "IX_OPGUsluge_OPGId",
                table: "OPGUsluge",
                column: "OPGId");

            migrationBuilder.CreateIndex(
                name: "IX_OPGUsluge_UslugaId",
                table: "OPGUsluge",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_VrstaProizvodaId",
                table: "Proizvodi",
                column: "VrstaProizvodaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbeProizvoda_NarudzbaId",
                table: "StavkeNarudzbeProizvoda",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbeProizvoda_ProizvodId",
                table: "StavkeNarudzbeProizvoda",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbeUsluga_NarudzbaId",
                table: "StavkeNarudzbeUsluga",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbeUsluga_UslugaId",
                table: "StavkeNarudzbeUsluga",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_StrojeviAlati_VrstaStrojaAlataId",
                table: "StrojeviAlati",
                column: "VrstaStrojaAlataId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_VrstaUslugeId",
                table: "Usluge",
                column: "VrstaUslugeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vlasnici_MjestoPrebivalistaId",
                table: "Vlasnici",
                column: "MjestoPrebivalistaId");

            migrationBuilder.CreateIndex(
                name: "IX_VlasniciOPG_OPGId",
                table: "VlasniciOPG",
                column: "OPGId");

            migrationBuilder.CreateIndex(
                name: "IX_VlasniciOPG_VlasnikId",
                table: "VlasniciOPG",
                column: "VlasnikId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DjelatnostiOPG");

            migrationBuilder.DropTable(
                name: "ImanjaVlasnici");

            migrationBuilder.DropTable(
                name: "OPGProizvodi");

            migrationBuilder.DropTable(
                name: "OPGStrojeviAlati");

            migrationBuilder.DropTable(
                name: "OPGUsluge");

            migrationBuilder.DropTable(
                name: "StavkeNarudzbeProizvoda");

            migrationBuilder.DropTable(
                name: "StavkeNarudzbeUsluga");

            migrationBuilder.DropTable(
                name: "VlasniciOPG");

            migrationBuilder.DropTable(
                name: "Djelatnosti");

            migrationBuilder.DropTable(
                name: "Imanja");

            migrationBuilder.DropTable(
                name: "StrojeviAlati");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Narudzbe");

            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropTable(
                name: "Vlasnici");

            migrationBuilder.DropTable(
                name: "VrsteStrojevaAlata");

            migrationBuilder.DropTable(
                name: "VrsteProizvoda");

            migrationBuilder.DropTable(
                name: "OPGs");

            migrationBuilder.DropTable(
                name: "StatusiNarudzbi");

            migrationBuilder.DropTable(
                name: "VrsteUsluga");

            migrationBuilder.DropTable(
                name: "Mjesta");

            migrationBuilder.DropTable(
                name: "Zupanije");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgroNet.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VlasnikId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Zupanije",
                columns: new[] { "Id", "Naziv" },
                values: new object[,]
                {
                    { 1, "Zagrebačka županija" },
                    { 2, "Krapinsko-zagorska županija" },
                    { 3, "Sisačko-moslavačka županija" },
                    { 4, "Karlovačka županija" },
                    { 5, "Varaždinska županija" },
                    { 6, "Koprivničko-križevačka županija" },
                    { 7, "Bjelovarsko-bilogorska županija" },
                    { 8, "Primorsko-goranska županija" },
                    { 9, "Ličko-senjska županija" },
                    { 10, "Virovitičko-podravska županija" },
                    { 11, "Požeško-slavonska županija" },
                    { 12, "Brodsko-posavska županija" },
                    { 13, "Zadarska županija" },
                    { 14, "Osječko-baranjska županija" },
                    { 15, "Šibensko-kninska županija" },
                    { 16, "Vukovarsko-srijemska županija" },
                    { 17, "Splitsko-dalmatinska županija" },
                    { 18, "Istarska županija" },
                    { 19, "Dubrovačko-neretvanska županija" },
                    { 20, "Međimurska županija" },
                    { 21, "Grad Zagreb" }
                });

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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

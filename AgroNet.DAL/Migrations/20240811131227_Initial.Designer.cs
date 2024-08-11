﻿// <auto-generated />
using System;
using AgroNet.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgroNet.DAL.Migrations
{
    [DbContext(typeof(AgroNetDbContext))]
    [Migration("20240811131227_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgroNet.Model.Djelatnost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Djelatnosti");
                });

            modelBuilder.Entity("AgroNet.Model.DjelatnostiOPG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DjelatnostId")
                        .HasColumnType("int");

                    b.Property<int>("OPGId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DjelatnostId");

                    b.HasIndex("OPGId");

                    b.ToTable("DjelatnostiOPG");
                });

            modelBuilder.Entity("AgroNet.Model.Imanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Katastar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Povrsina")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Imanja");
                });

            modelBuilder.Entity("AgroNet.Model.ImanjeVlasnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ImanjeId")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.Property<int>("VlasnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImanjeId");

                    b.HasIndex("ProizvodId");

                    b.HasIndex("VlasnikId");

                    b.ToTable("ImanjaVlasnici");
                });

            modelBuilder.Entity("AgroNet.Model.Mjesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PostanskiBroj")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("ZupanijaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZupanijaId");

                    b.ToTable("Mjesta");
                });

            modelBuilder.Entity("AgroNet.Model.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DatumIsporuke")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumNarudzbe")
                        .HasColumnType("datetime2");

                    b.Property<int>("KupacOPGId")
                        .HasColumnType("int");

                    b.Property<int>("ProdavacOPGId")
                        .HasColumnType("int");

                    b.Property<int>("StatusNarudzbeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KupacOPGId");

                    b.HasIndex("ProdavacOPGId");

                    b.HasIndex("StatusNarudzbeId");

                    b.ToTable("Narudzbe");
                });

            modelBuilder.Entity("AgroNet.Model.OPG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MjestoId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MjestoId");

                    b.ToTable("OPGs");
                });

            modelBuilder.Entity("AgroNet.Model.OPGProizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OPGId")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OPGId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("OPGProizvodi");
                });

            modelBuilder.Entity("AgroNet.Model.OPGStrojeviAlati", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OPGId")
                        .HasColumnType("int");

                    b.Property<int>("StrojAlatId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OPGId");

                    b.HasIndex("StrojAlatId");

                    b.ToTable("OPGStrojeviAlati");
                });

            modelBuilder.Entity("AgroNet.Model.OPGUsluga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OPGId")
                        .HasColumnType("int");

                    b.Property<int>("UslugaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OPGId");

                    b.HasIndex("UslugaId");

                    b.ToTable("OPGUsluge");
                });

            modelBuilder.Entity("AgroNet.Model.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VrstaProizvodaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VrstaProizvodaId");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("AgroNet.Model.StatusNarudzbe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StatusiNarudzbi");
                });

            modelBuilder.Entity("AgroNet.Model.StavkaNarudzbeProizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("JedinicnaCijena")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("StavkeNarudzbeProizvoda");
                });

            modelBuilder.Entity("AgroNet.Model.StavkaNarudzbeUsluga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("JedinicnaCijena")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int");

                    b.Property<int>("UslugaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("UslugaId");

                    b.ToTable("StavkeNarudzbeUsluga");
                });

            modelBuilder.Entity("AgroNet.Model.StrojAlat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VrstaStrojaAlataId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VrstaStrojaAlataId");

                    b.ToTable("StrojeviAlati");
                });

            modelBuilder.Entity("AgroNet.Model.Usluga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VrstaUslugeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VrstaUslugeId");

                    b.ToTable("Usluge");
                });

            modelBuilder.Entity("AgroNet.Model.Vlasnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MjestoPrebivalistaId")
                        .HasColumnType("int");

                    b.Property<string>("OIB")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("MjestoPrebivalistaId");

                    b.ToTable("Vlasnici");
                });

            modelBuilder.Entity("AgroNet.Model.VlasnikOPG", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OPGId")
                        .HasColumnType("int");

                    b.Property<int>("VlasnikId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OPGId");

                    b.HasIndex("VlasnikId");

                    b.ToTable("VlasniciOPG");
                });

            modelBuilder.Entity("AgroNet.Model.VrstaProizvoda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VrsteProizvoda");
                });

            modelBuilder.Entity("AgroNet.Model.VrstaStrojaAlata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VrsteStrojevaAlata");
                });

            modelBuilder.Entity("AgroNet.Model.VrstaUsluge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VrsteUsluga");
                });

            modelBuilder.Entity("AgroNet.Model.Zupanija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zupanije");
                });

            modelBuilder.Entity("AgroNet.Model.DjelatnostiOPG", b =>
                {
                    b.HasOne("AgroNet.Model.Djelatnost", "Djelatnost")
                        .WithMany()
                        .HasForeignKey("DjelatnostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.OPG", "OPG")
                        .WithMany()
                        .HasForeignKey("OPGId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Djelatnost");

                    b.Navigation("OPG");
                });

            modelBuilder.Entity("AgroNet.Model.ImanjeVlasnik", b =>
                {
                    b.HasOne("AgroNet.Model.Imanje", "Imanje")
                        .WithMany()
                        .HasForeignKey("ImanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.Vlasnik", "Vlasnik")
                        .WithMany()
                        .HasForeignKey("VlasnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imanje");

                    b.Navigation("Proizvod");

                    b.Navigation("Vlasnik");
                });

            modelBuilder.Entity("AgroNet.Model.Mjesto", b =>
                {
                    b.HasOne("AgroNet.Model.Zupanija", "Zupanija")
                        .WithMany()
                        .HasForeignKey("ZupanijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Zupanija");
                });

            modelBuilder.Entity("AgroNet.Model.Narudzba", b =>
                {
                    b.HasOne("AgroNet.Model.OPG", "KupacOPG")
                        .WithMany()
                        .HasForeignKey("KupacOPGId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.OPG", "ProdavacOPG")
                        .WithMany()
                        .HasForeignKey("ProdavacOPGId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.StatusNarudzbe", "StatusNarudzbe")
                        .WithMany()
                        .HasForeignKey("StatusNarudzbeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KupacOPG");

                    b.Navigation("ProdavacOPG");

                    b.Navigation("StatusNarudzbe");
                });

            modelBuilder.Entity("AgroNet.Model.OPG", b =>
                {
                    b.HasOne("AgroNet.Model.Mjesto", "Mjesto")
                        .WithMany()
                        .HasForeignKey("MjestoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mjesto");
                });

            modelBuilder.Entity("AgroNet.Model.OPGProizvod", b =>
                {
                    b.HasOne("AgroNet.Model.OPG", "OPG")
                        .WithMany()
                        .HasForeignKey("OPGId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OPG");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("AgroNet.Model.OPGStrojeviAlati", b =>
                {
                    b.HasOne("AgroNet.Model.OPG", "OPG")
                        .WithMany()
                        .HasForeignKey("OPGId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.StrojAlat", "StrojAlat")
                        .WithMany()
                        .HasForeignKey("StrojAlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OPG");

                    b.Navigation("StrojAlat");
                });

            modelBuilder.Entity("AgroNet.Model.OPGUsluga", b =>
                {
                    b.HasOne("AgroNet.Model.OPG", "OPG")
                        .WithMany()
                        .HasForeignKey("OPGId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.Usluga", "Usluga")
                        .WithMany()
                        .HasForeignKey("UslugaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OPG");

                    b.Navigation("Usluga");
                });

            modelBuilder.Entity("AgroNet.Model.Proizvod", b =>
                {
                    b.HasOne("AgroNet.Model.VrstaProizvoda", "VrstaProizvoda")
                        .WithMany()
                        .HasForeignKey("VrstaProizvodaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VrstaProizvoda");
                });

            modelBuilder.Entity("AgroNet.Model.StavkaNarudzbeProizvod", b =>
                {
                    b.HasOne("AgroNet.Model.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Narudzba");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("AgroNet.Model.StavkaNarudzbeUsluga", b =>
                {
                    b.HasOne("AgroNet.Model.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.Usluga", "Usluga")
                        .WithMany()
                        .HasForeignKey("UslugaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Narudzba");

                    b.Navigation("Usluga");
                });

            modelBuilder.Entity("AgroNet.Model.StrojAlat", b =>
                {
                    b.HasOne("AgroNet.Model.VrstaStrojaAlata", "VrstaStrojaAlata")
                        .WithMany()
                        .HasForeignKey("VrstaStrojaAlataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VrstaStrojaAlata");
                });

            modelBuilder.Entity("AgroNet.Model.Usluga", b =>
                {
                    b.HasOne("AgroNet.Model.VrstaUsluge", "VrstaUsluge")
                        .WithMany()
                        .HasForeignKey("VrstaUslugeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VrstaUsluge");
                });

            modelBuilder.Entity("AgroNet.Model.Vlasnik", b =>
                {
                    b.HasOne("AgroNet.Model.Mjesto", "MjestoPrebivalista")
                        .WithMany()
                        .HasForeignKey("MjestoPrebivalistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MjestoPrebivalista");
                });

            modelBuilder.Entity("AgroNet.Model.VlasnikOPG", b =>
                {
                    b.HasOne("AgroNet.Model.OPG", "OPG")
                        .WithMany()
                        .HasForeignKey("OPGId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AgroNet.Model.Vlasnik", "Vlasnik")
                        .WithMany()
                        .HasForeignKey("VlasnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OPG");

                    b.Navigation("Vlasnik");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using JornadaMilhasV0.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JornadaMilhasV0.Migrations
{
    [DbContext(typeof(JornadaMilhasContext))]
    [Migration("20240116174343_ProjetoInicial")]
    partial class ProjetoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JornadaMilhasV0.Modelos.OfertaViagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataIda")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVolta")
                        .HasColumnType("datetime2");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("RotaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RotaId");

                    b.ToTable("OfertasViagem");
                });

            modelBuilder.Entity("JornadaMilhasV0.Modelos.Rota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rota");
                });

            modelBuilder.Entity("JornadaMilhasV0.Modelos.OfertaViagem", b =>
                {
                    b.HasOne("JornadaMilhasV0.Modelos.Rota", "Rota")
                        .WithMany()
                        .HasForeignKey("RotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rota");
                });
#pragma warning restore 612, 618
        }
    }
}

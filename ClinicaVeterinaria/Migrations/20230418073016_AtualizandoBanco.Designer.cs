﻿// <auto-generated />
using System;
using ClinicaVeterinaria.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicaVeterinaria.API.Migrations
{
    [DbContext(typeof(ClinicaVeterinariaDBContext))]
    [Migration("20230418073016_AtualizandoBanco")]
    partial class AtualizandoBanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClinicaVeterinaria.API.Models.AgendamentoModel", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AgendamentoId"), 1L, 1);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<bool>("VeterinarioGeriatrico")
                        .HasColumnType("bit");

                    b.Property<int>("VeterinarioId")
                        .HasColumnType("int");

                    b.Property<string>("VeterinarioNome")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("AgendamentoId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("ClinicaVeterinaria.API.Models.AnimalModel", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalId"), 1L, 1);

                    b.Property<int>("CategoriaAnimal")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Geriatria")
                        .HasColumnType("bit");

                    b.Property<int>("IdadeAnimal")
                        .HasColumnType("int");

                    b.Property<string>("NomeAnimal")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("AnimalId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("ClinicaVeterinaria.API.Models.AtendimentoModel", b =>
                {
                    b.Property<int>("AtendimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AtendimentoId"), 1L, 1);

                    b.Property<DateTime>("DataAtendimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasKey("AtendimentoId");

                    b.HasIndex("VeterinarioId");

                    b.ToTable("Atendimento");
                });

            modelBuilder.Entity("ClinicaVeterinaria.API.Models.ClienteModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("CpfCliente")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ClinicaVeterinaria.API.Models.VeterinarioModel", b =>
                {
                    b.Property<int>("VeterinarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VeterinarioId"), 1L, 1);

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Geriatria")
                        .HasColumnType("bit");

                    b.Property<string>("NomeVeterinario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("VeterinarioId");

                    b.ToTable("Veterinarios");
                });

            modelBuilder.Entity("ClinicaVeterinaria.API.Models.AgendamentoModel", b =>
                {
                    b.HasOne("ClinicaVeterinaria.API.Models.AnimalModel", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicaVeterinaria.API.Models.VeterinarioModel", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("ClinicaVeterinaria.API.Models.AnimalModel", b =>
                {
                    b.HasOne("ClinicaVeterinaria.API.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ClinicaVeterinaria.API.Models.AtendimentoModel", b =>
                {
                    b.HasOne("ClinicaVeterinaria.API.Models.VeterinarioModel", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId");

                    b.Navigation("Veterinario");
                });
#pragma warning restore 612, 618
        }
    }
}

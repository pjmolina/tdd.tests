﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Unir.Repositories.Impl.Context;

namespace Services.Migrations
{
    [DbContext(typeof(PlanesDbContext))]
    [Migration("20181120165553_DatosIniciales")]
    partial class DatosIniciales
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Unir.Aggregates.Asignaturas.Asignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.Property<bool>("Optativa");

                    b.Property<int?>("PlanId");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("Asignatura");

                    b.HasData(
                        new { Id = 1, Nombre = "Análisis Matemático", Optativa = false },
                        new { Id = 2, Nombre = "BI", Optativa = true }
                    );
                });

            modelBuilder.Entity("Unir.Aggregates.Estudios.Estudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AprobadoAneca");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Estudio");

                    b.HasData(
                        new { Id = 1, AprobadoAneca = true, Nombre = "Matemática" }
                    );
                });

            modelBuilder.Entity("Unir.Aggregates.Estudios.TraduccionEstudio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EstudioId");

                    b.Property<string>("Locale");

                    b.Property<string>("Traduccion");

                    b.HasKey("Id");

                    b.HasIndex("EstudioId");

                    b.ToTable("TraduccionEstudio");
                });

            modelBuilder.Entity("Unir.Aggregates.Planes.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aprobado");

                    b.Property<int?>("EstudioId");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("EstudioId");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("Unir.Aggregates.Asignaturas.Asignatura", b =>
                {
                    b.HasOne("Unir.Aggregates.Planes.Plan")
                        .WithMany("Asignaturas")
                        .HasForeignKey("PlanId");
                });

            modelBuilder.Entity("Unir.Aggregates.Estudios.TraduccionEstudio", b =>
                {
                    b.HasOne("Unir.Aggregates.Estudios.Estudio", "Estudio")
                        .WithMany("Traducciones")
                        .HasForeignKey("EstudioId");
                });

            modelBuilder.Entity("Unir.Aggregates.Planes.Plan", b =>
                {
                    b.HasOne("Unir.Aggregates.Estudios.Estudio", "Estudio")
                        .WithMany()
                        .HasForeignKey("EstudioId");
                });
#pragma warning restore 612, 618
        }
    }
}

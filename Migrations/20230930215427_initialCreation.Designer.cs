﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecyclU.Data;

#nullable disable

namespace RecyclU.Migrations
{
    [DbContext(typeof(RecyclUContext))]
    [Migration("20230930215427_initialCreation")]
    partial class initialCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecyclU.Models.Negocio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmpresaEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Monto")
                        .HasColumnType("real");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<string>("UniversidadEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaEmail");

                    b.HasIndex("UniversidadEmail");

                    b.ToTable("Negocio");
                });

            modelBuilder.Entity("RecyclU.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Peso")
                        .HasColumnType("real");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<string>("UniversidadEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UniversidadEmail");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("RecyclU.Models.Usuario", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RecyclU.Models.Empresa", b =>
                {
                    b.HasBaseType("RecyclU.Models.Usuario");

                    b.HasDiscriminator().HasValue("Empresa");
                });

            modelBuilder.Entity("RecyclU.Models.Universidad", b =>
                {
                    b.HasBaseType("RecyclU.Models.Usuario");

                    b.HasDiscriminator().HasValue("Universidad");
                });

            modelBuilder.Entity("RecyclU.Models.Negocio", b =>
                {
                    b.HasOne("RecyclU.Models.Empresa", "Empresa")
                        .WithMany("Negocios")
                        .HasForeignKey("EmpresaEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecyclU.Models.Universidad", "Universidad")
                        .WithMany("Negocios")
                        .HasForeignKey("UniversidadEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Universidad");
                });

            modelBuilder.Entity("RecyclU.Models.Post", b =>
                {
                    b.HasOne("RecyclU.Models.Universidad", null)
                        .WithMany("Posts")
                        .HasForeignKey("UniversidadEmail");
                });

            modelBuilder.Entity("RecyclU.Models.Empresa", b =>
                {
                    b.Navigation("Negocios");
                });

            modelBuilder.Entity("RecyclU.Models.Universidad", b =>
                {
                    b.Navigation("Negocios");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}

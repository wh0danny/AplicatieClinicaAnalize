﻿// <auto-generated />
using AplicatieClinicaAnalize.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AplicatieClinicaAnalize.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230610163153_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AplicatieClinicaAnalize.Models.Analiza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategorieAnaliza")
                        .HasColumnType("int");

                    b.Property<int>("ClinicaId")
                        .HasColumnType("int");

                    b.Property<string>("NumeAnaliza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PretAnaliza")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.ToTable("Analize");
                });

            modelBuilder.Entity("AplicatieClinicaAnalize.Models.Clinica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DescriereClinica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoClinica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeClinica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clinici");
                });

            modelBuilder.Entity("AplicatieClinicaAnalize.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DespreDoctor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeDoctor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PozaDeProfilURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctori");
                });

            modelBuilder.Entity("AplicatieClinicaAnalize.Models.Doctor_Analiza", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("AnalizaId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId", "AnalizaId");

                    b.HasIndex("AnalizaId");

                    b.ToTable("Doctori_Analize");
                });

            modelBuilder.Entity("AplicatieClinicaAnalize.Models.Analiza", b =>
                {
                    b.HasOne("AplicatieClinicaAnalize.Models.Clinica", "Clinica")
                        .WithMany("Analize")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");
                });

            modelBuilder.Entity("AplicatieClinicaAnalize.Models.Doctor_Analiza", b =>
                {
                    b.HasOne("AplicatieClinicaAnalize.Models.Analiza", "Analiza")
                        .WithMany("Doctori_Analize")
                        .HasForeignKey("AnalizaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AplicatieClinicaAnalize.Models.Doctor", "Doctor")
                        .WithMany("Doctori_Analize")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Analiza");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("AplicatieClinicaAnalize.Models.Analiza", b =>
                {
                    b.Navigation("Doctori_Analize");
                });

            modelBuilder.Entity("AplicatieClinicaAnalize.Models.Clinica", b =>
                {
                    b.Navigation("Analize");
                });

            modelBuilder.Entity("AplicatieClinicaAnalize.Models.Doctor", b =>
                {
                    b.Navigation("Doctori_Analize");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using System.Collections.Generic;
using CLOUD.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CLOUD.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CLOUD.Auth.Temperatura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PacientId")
                        .HasColumnType("uuid");

                    b.Property<int>("Valoare")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("Temperatura");
                });

            modelBuilder.Entity("CLOUD.Auth.Umiditate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PacientId")
                        .HasColumnType("uuid");

                    b.Property<float>("Valoare")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("Umiditate");
                });

            modelBuilder.Entity("CLOUD.DateMedicale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<string>>("Alergii")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("ConsulatatiiCardiologice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IstoricMedical")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PacientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("DateMedicale");
                });

            modelBuilder.Entity("CLOUD.ECG", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PacientId")
                        .HasColumnType("uuid");

                    b.Property<List<float>>("Valori")
                        .IsRequired()
                        .HasColumnType("real[]");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("Ecg");
                });

            modelBuilder.Entity("CLOUD.Judet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Jud")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Judete");
                });

            modelBuilder.Entity("CLOUD.Medic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TipMedic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Medici");
                });

            modelBuilder.Entity("CLOUD.MedicPacienti", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("MedicId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PacientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("MedicId");

                    b.HasIndex("PacientId");

                    b.ToTable("MedicPacienti");
                });

            modelBuilder.Entity("CLOUD.Pacient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CNP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("JudetId")
                        .HasColumnType("uuid");

                    b.Property<string>("LocDeMunca")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Localitate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Profestie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<short>("Varsta")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("JudetId");

                    b.HasIndex("UserId");

                    b.ToTable("Pacienti");
                });

            modelBuilder.Entity("CLOUD.Puls", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PacientId")
                        .HasColumnType("uuid");

                    b.Property<float>("Valoare")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("Puls");
                });

            modelBuilder.Entity("CLOUD.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CLOUD.ValoriNormaleSenzori", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PacientId")
                        .HasColumnType("uuid");

                    b.Property<int>("PulsMaxim")
                        .HasColumnType("integer");

                    b.Property<int>("PulsMinim")
                        .HasColumnType("integer");

                    b.Property<int>("TemperaturaMaxima")
                        .HasColumnType("integer");

                    b.Property<int>("TemperaturaMinima")
                        .HasColumnType("integer");

                    b.Property<int>("UmiditateMaxima")
                        .HasColumnType("integer");

                    b.Property<int>("UmiditateMinima")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PacientId");

                    b.ToTable("ValoriNormaleSenzori");
                });

            modelBuilder.Entity("CLOUD.Auth.Temperatura", b =>
                {
                    b.HasOne("CLOUD.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("CLOUD.Auth.Umiditate", b =>
                {
                    b.HasOne("CLOUD.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("CLOUD.DateMedicale", b =>
                {
                    b.HasOne("CLOUD.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("CLOUD.ECG", b =>
                {
                    b.HasOne("CLOUD.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("CLOUD.Medic", b =>
                {
                    b.HasOne("CLOUD.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLOUD.MedicPacienti", b =>
                {
                    b.HasOne("CLOUD.Medic", "Medic")
                        .WithMany()
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CLOUD.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medic");

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("CLOUD.Pacient", b =>
                {
                    b.HasOne("CLOUD.Judet", "Judet")
                        .WithMany()
                        .HasForeignKey("JudetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CLOUD.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Judet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLOUD.Puls", b =>
                {
                    b.HasOne("CLOUD.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("CLOUD.ValoriNormaleSenzori", b =>
                {
                    b.HasOne("CLOUD.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacient");
                });
#pragma warning restore 612, 618
        }
    }
}

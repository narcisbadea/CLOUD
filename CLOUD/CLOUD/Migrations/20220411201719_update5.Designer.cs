﻿// <auto-generated />
using System;
using System.Collections.Generic;
using CLOUD.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CLOUD.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220411201719_update5")]
    partial class update5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CLOUD.Auth.Alergie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("DateMedicaleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Simptome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TipAlergie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DateMedicaleId");

                    b.ToTable("Alergii");
                });

            modelBuilder.Entity("CLOUD.Auth.DateMedicale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConsulatatiiCardiologice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IstoricMedicalId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PacientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("IstoricMedicalId");

                    b.HasIndex("PacientId");

                    b.ToTable("DateMedicale");
                });

            modelBuilder.Entity("CLOUD.Auth.ECG", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<List<float>>("Valori")
                        .IsRequired()
                        .HasColumnType("real[]");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Ecgs");
                });

            modelBuilder.Entity("CLOUD.Auth.IstoricMedical", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProblemaMedicala")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Tratament")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("IstoricMedicals");
                });

            modelBuilder.Entity("CLOUD.Auth.Judet", b =>
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

            modelBuilder.Entity("CLOUD.Auth.Medic", b =>
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

            modelBuilder.Entity("CLOUD.Auth.MedicPacienti", b =>
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

            modelBuilder.Entity("CLOUD.Auth.Pacient", b =>
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

            modelBuilder.Entity("CLOUD.Auth.Puls", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<float>("Valoare")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pulss");
                });

            modelBuilder.Entity("CLOUD.Auth.Temperatura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<int>("Valoare")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Temperaturi");
                });

            modelBuilder.Entity("CLOUD.Auth.Umiditate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<float>("Valoare")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Umiditates");
                });

            modelBuilder.Entity("CLOUD.Auth.User", b =>
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

            modelBuilder.Entity("CLOUD.Auth.Alergie", b =>
                {
                    b.HasOne("CLOUD.Auth.DateMedicale", null)
                        .WithMany("Alergii")
                        .HasForeignKey("DateMedicaleId");
                });

            modelBuilder.Entity("CLOUD.Auth.DateMedicale", b =>
                {
                    b.HasOne("CLOUD.Auth.IstoricMedical", "IstoricMedical")
                        .WithMany()
                        .HasForeignKey("IstoricMedicalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CLOUD.Auth.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IstoricMedical");

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("CLOUD.Auth.ECG", b =>
                {
                    b.HasOne("CLOUD.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLOUD.Auth.Medic", b =>
                {
                    b.HasOne("CLOUD.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLOUD.Auth.MedicPacienti", b =>
                {
                    b.HasOne("CLOUD.Auth.Medic", "Medic")
                        .WithMany()
                        .HasForeignKey("MedicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CLOUD.Auth.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medic");

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("CLOUD.Auth.Pacient", b =>
                {
                    b.HasOne("CLOUD.Auth.Judet", "Judet")
                        .WithMany()
                        .HasForeignKey("JudetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CLOUD.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Judet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLOUD.Auth.Puls", b =>
                {
                    b.HasOne("CLOUD.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLOUD.Auth.Temperatura", b =>
                {
                    b.HasOne("CLOUD.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLOUD.Auth.Umiditate", b =>
                {
                    b.HasOne("CLOUD.Auth.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CLOUD.Auth.DateMedicale", b =>
                {
                    b.Navigation("Alergii");
                });
#pragma warning restore 612, 618
        }
    }
}

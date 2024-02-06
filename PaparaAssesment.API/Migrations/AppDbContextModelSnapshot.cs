﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaparaAssesment.API.Models;

#nullable disable

namespace PaparaAssesment.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PaparaAssesment.API.Models.Flats.Flat", b =>
                {
                    b.Property<int>("FlatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlatId"));

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlatNumber")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlatId");

                    b.HasIndex("PaymentId");

                    b.ToTable("Flats", (string)null);
                });

            modelBuilder.Entity("PaparaAssesment.API.Models.Payments.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int?>("ResidentId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("ResidentId");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("PaparaAssesment.API.Models.Residents.Resident", b =>
                {
                    b.Property<int>("ResidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResidentId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlatId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResidentId");

                    b.HasIndex("FlatId")
                        .IsUnique();

                    b.ToTable("Residents", (string)null);
                });

            modelBuilder.Entity("PaparaAssesment.API.Models.Flats.Flat", b =>
                {
                    b.HasOne("PaparaAssesment.API.Models.Payments.Payment", "Payments")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("PaparaAssesment.API.Models.Payments.Payment", b =>
                {
                    b.HasOne("PaparaAssesment.API.Models.Residents.Resident", "Resident")
                        .WithMany("Payments")
                        .HasForeignKey("ResidentId");

                    b.Navigation("Resident");
                });

            modelBuilder.Entity("PaparaAssesment.API.Models.Residents.Resident", b =>
                {
                    b.HasOne("PaparaAssesment.API.Models.Flats.Flat", "Flats")
                        .WithOne("Residents")
                        .HasForeignKey("PaparaAssesment.API.Models.Residents.Resident", "FlatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flats");
                });

            modelBuilder.Entity("PaparaAssesment.API.Models.Flats.Flat", b =>
                {
                    b.Navigation("Residents");
                });

            modelBuilder.Entity("PaparaAssesment.API.Models.Residents.Resident", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
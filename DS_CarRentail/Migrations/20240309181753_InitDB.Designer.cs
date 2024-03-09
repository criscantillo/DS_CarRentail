﻿// <auto-generated />
using DS_CarRentail.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DS_CarRentail.Migrations
{
    [DbContext(typeof(CarRentailContext))]
    [Migration("20240309181753_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.16");

            modelBuilder.Entity("DS_CarRentail.Infrastructure.Database.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasAC")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TransmissionAuot")
                        .HasColumnType("INTEGER");

                    b.HasKey("CarId");

                    b.ToTable("Car", (string)null);
                });

            modelBuilder.Entity("DS_CarRentail.Infrastructure.Database.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CompanyId");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("DS_CarRentail.Infrastructure.Database.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("DS_CarRentail.Infrastructure.Database.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("DS_CarRentail.Infrastructure.Database.Location", b =>
                {
                    b.HasOne("DS_CarRentail.Infrastructure.Database.Company", "Company")
                        .WithMany("Locations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DS_CarRentail.Infrastructure.Database.Company", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
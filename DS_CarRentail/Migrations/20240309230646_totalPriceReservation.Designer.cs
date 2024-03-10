﻿// <auto-generated />
using System;
using DS_CarRentail.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DS_CarRentail.Migrations
{
    [DbContext(typeof(CarRentailContext))]
    [Migration("20240309230646_totalPriceReservation")]
    partial class totalPriceReservation
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

                    b.Property<bool>("HasAC")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TransmissionAuto")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
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

                    b.Property<string>("Coordinates")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("DS_CarRentail.Infrastructure.Database.LocationCar", b =>
                {
                    b.Property<int>("LocationCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CarPriceForDay")
                        .HasColumnType("TEXT");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("InDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OutDate")
                        .HasColumnType("TEXT");

                    b.HasKey("LocationCarId");

                    b.HasIndex("CarId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationCar", (string)null);
                });

            modelBuilder.Entity("DS_CarRentail.Infrastructure.Database.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("From")
                        .HasColumnType("TEXT");

                    b.Property<int>("LocationCarId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationDestination")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationOrigin")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("To")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservationId");

                    b.HasIndex("LocationCarId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservation", (string)null);
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

            modelBuilder.Entity("DS_CarRentail.Infrastructure.Database.LocationCar", b =>
                {
                    b.HasOne("DS_CarRentail.Infrastructure.Database.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DS_CarRentail.Infrastructure.Database.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DS_CarRentail.Infrastructure.Database.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Company");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DS_CarRentail.Infrastructure.Database.Reservation", b =>
                {
                    b.HasOne("DS_CarRentail.Infrastructure.Database.LocationCar", "LocationCar")
                        .WithMany()
                        .HasForeignKey("LocationCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DS_CarRentail.Infrastructure.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocationCar");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}

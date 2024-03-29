﻿// <auto-generated />
using System;
using LeMounAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LeMounAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LeMounAPI.Models.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("OrderEnded")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("VehicleId")
                        .HasColumnType("bigint");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("LeMounAPI.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("StatusId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LeMounAPI.Models.UserRole", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LeMounAPI.Models.UserStatus", b =>
                {
                    b.Property<long>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("LeMounAPI.Models.Vehicle", b =>
                {
                    b.Property<long>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Battery")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsRented")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Lattitude")
                        .HasColumnType("double");

                    b.Property<double>("Longtitude")
                        .HasColumnType("double");

                    b.Property<decimal>("StartupPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("UnderMaintenance")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VehicleId");

                    b.HasIndex("TypeId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("LeMounAPI.Models.VehicleType", b =>
                {
                    b.Property<long>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TypeId");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("LeMounAPI.Models.Order", b =>
                {
                    b.HasOne("LeMounAPI.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeMounAPI.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("LeMounAPI.Models.User", b =>
                {
                    b.HasOne("LeMounAPI.Models.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeMounAPI.Models.UserStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("LeMounAPI.Models.Vehicle", b =>
                {
                    b.HasOne("LeMounAPI.Models.VehicleType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("LeMounAPI.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

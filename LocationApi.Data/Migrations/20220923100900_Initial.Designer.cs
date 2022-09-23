﻿// <auto-generated />
using System;
using LocationApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocationApi.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220923100900_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("LocationApi.Domain.Entities.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AreaName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AreaId");

                    b.HasIndex("CityId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CityName")
                        .HasColumnType("TEXT");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StateId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Iso")
                        .HasColumnType("TEXT");

                    b.Property<string>("Iso3")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.Estate", b =>
                {
                    b.Property<int>("EstateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EstateName")
                        .HasColumnType("TEXT");

                    b.HasKey("EstateId");

                    b.HasIndex("CityId");

                    b.ToTable("Estates");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AreaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EstateId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StateId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<int?>("StreetId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.HasIndex("AreaId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("EstateId");

                    b.HasIndex("StateId");

                    b.HasIndex("StreetId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StateName")
                        .HasColumnType("TEXT");

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.Street", b =>
                {
                    b.Property<int>("StreetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Isverified")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StreetName")
                        .HasColumnType("TEXT");

                    b.HasKey("StreetId");

                    b.HasIndex("CityId");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.Area", b =>
                {
                    b.HasOne("LocationApi.Domain.Entities.City", "City")
                        .WithMany("Areas")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.City", b =>
                {
                    b.HasOne("LocationApi.Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocationApi.Domain.Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("State");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.Estate", b =>
                {
                    b.HasOne("LocationApi.Domain.Entities.City", "City")
                        .WithMany("Estates")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.Location", b =>
                {
                    b.HasOne("LocationApi.Domain.Entities.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("LocationApi.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("LocationApi.Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("LocationApi.Domain.Entities.Estate", "Estate")
                        .WithMany()
                        .HasForeignKey("EstateId");

                    b.HasOne("LocationApi.Domain.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.HasOne("LocationApi.Domain.Entities.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId");

                    b.Navigation("Area");

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Estate");

                    b.Navigation("State");

                    b.Navigation("Street");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.State", b =>
                {
                    b.HasOne("LocationApi.Domain.Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.Street", b =>
                {
                    b.HasOne("LocationApi.Domain.Entities.City", "City")
                        .WithMany("Streets")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.City", b =>
                {
                    b.Navigation("Areas");

                    b.Navigation("Estates");

                    b.Navigation("Streets");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("LocationApi.Domain.Entities.State", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}

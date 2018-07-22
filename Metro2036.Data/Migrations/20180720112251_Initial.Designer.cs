﻿// <auto-generated />
using System;
using Metro2036.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Metro2036.Data.Migrations
{
    [DbContext(typeof(Metro2036DbContext))]
    [Migration("20180720112251_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Metro2036.Models.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<int?>("RouteId");

                    b.Property<int>("StopCode");

                    b.Property<string>("StopName")
                        .IsRequired();

                    b.Property<int>("VehicleType");

                    b.Property<int>("stop");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("Metro2036.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExtId");

                    b.Property<int>("LineId");

                    b.Property<int>("LineName");

                    b.Property<int>("RouteId");

                    b.Property<string>("RouteName")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Metro2036.Models.RouteStation", b =>
                {
                    b.Property<int>("RouteId");

                    b.Property<int>("StationId");

                    b.Property<string>("RouteName");

                    b.Property<string>("StationName");

                    b.HasKey("RouteId", "StationId");

                    b.HasIndex("StationId");

                    b.ToTable("RouteStations");
                });

            modelBuilder.Entity("Metro2036.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18,6)");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PointId");

                    b.Property<int>("RouteId");

                    b.Property<int>("StantionId");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("Metro2036.Models.Point", b =>
                {
                    b.HasOne("Metro2036.Models.Route")
                        .WithMany("Points")
                        .HasForeignKey("RouteId");
                });

            modelBuilder.Entity("Metro2036.Models.RouteStation", b =>
                {
                    b.HasOne("Metro2036.Models.Route")
                        .WithMany("RouteStations")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Metro2036.Models.Station")
                        .WithMany("RouteStations")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

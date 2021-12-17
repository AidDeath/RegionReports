﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegionReports.Data;

#nullable disable

namespace RegionReports.Data.Migrations
{
    [DbContext(typeof(RegionReportsContext))]
    [Migration("20211216090910_Id field type set to int")]
    partial class Idfieldtypesettoint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("RegionReports.Data.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RegionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DistrictId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WindowsUserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("ReportUsers");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.District", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportUser", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });
#pragma warning restore 612, 618
        }
    }
}

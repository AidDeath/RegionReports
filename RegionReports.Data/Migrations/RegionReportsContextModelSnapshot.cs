﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegionReports.Data;

#nullable disable

namespace RegionReports.Data.Migrations
{
    [DbContext(typeof(RegionReportsContext))]
    partial class RegionReportsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("RegionReports.Data.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RegionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DistrictName = "Березино",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 2,
                            DistrictName = "Борисов",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 3,
                            DistrictName = "Вилейка",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 4,
                            DistrictName = "Воложин",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 5,
                            DistrictName = "Дзержинск",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 6,
                            DistrictName = "Жодино",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 7,
                            DistrictName = "Клецк",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 8,
                            DistrictName = "Копыль",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 9,
                            DistrictName = "Крупки",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 10,
                            DistrictName = "Логойск",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 11,
                            DistrictName = "Любань",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 12,
                            DistrictName = "Минск",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 13,
                            DistrictName = "Молодечно",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 14,
                            DistrictName = "Мядель",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 15,
                            DistrictName = "Несвиж",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 16,
                            DistrictName = "Пуховичи",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 17,
                            DistrictName = "Слуцк",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 18,
                            DistrictName = "Смолевичи",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 19,
                            DistrictName = "Солигорск",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 20,
                            DistrictName = "Старые Дороги",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 21,
                            DistrictName = "Столбцы",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 22,
                            DistrictName = "Узда",
                            RegionId = 6
                        },
                        new
                        {
                            Id = 23,
                            DistrictName = "Червень",
                            RegionId = 6
                        });
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RegionName = "Брестская область"
                        },
                        new
                        {
                            Id = 2,
                            RegionName = "Гродненская область"
                        },
                        new
                        {
                            Id = 3,
                            RegionName = "Витебская область"
                        },
                        new
                        {
                            Id = 4,
                            RegionName = "Могилевская область"
                        },
                        new
                        {
                            Id = 5,
                            RegionName = "Гомельская область"
                        },
                        new
                        {
                            Id = 6,
                            RegionName = "Минская область"
                        });
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

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegionReports.Data;

#nullable disable

namespace RegionReports.Data.Migrations
{
    [DbContext(typeof(RegionReportsContext))]
    [Migration("20220314141411_Added field to claims table")]
    partial class Addedfieldtoclaimstable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RegionReports.Data.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int?>("ReportUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("ReportUserId")
                        .IsUnique()
                        .HasFilter("[ReportUserId] IS NOT NULL");

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastChangesDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("PreviousApprovalState")
                        .HasColumnType("bit");

                    b.Property<string>("UserDomain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WindowsUserName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.HasKey("Id");

                    b.ToTable("ReportUsers");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportUserApprovalClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ClaimDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsClaimProcessed")
                        .HasColumnType("bit");

                    b.Property<int>("ReportUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportUserId");

                    b.ToTable("ReportUserApprovalClaims");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportUserSuggestedChanges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RelatedDistrictId")
                        .HasColumnType("int");

                    b.Property<int>("ReportUserApprovalClaimId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RelatedDistrictId");

                    b.HasIndex("ReportUserApprovalClaimId")
                        .IsUnique();

                    b.ToTable("ReportUserSuggestedChanges");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.District", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.Region", "Region")
                        .WithMany("Districts")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegionReports.Data.Entities.ReportUser", "ReportUser")
                        .WithOne("RelatedDistrict")
                        .HasForeignKey("RegionReports.Data.Entities.District", "ReportUserId");

                    b.Navigation("Region");

                    b.Navigation("ReportUser");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportUserApprovalClaim", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.ReportUser", "ReportUser")
                        .WithMany("UserApprovalClaims")
                        .HasForeignKey("ReportUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportUser");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportUserSuggestedChanges", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.District", "RelatedDistrict")
                        .WithMany()
                        .HasForeignKey("RelatedDistrictId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RegionReports.Data.Entities.ReportUserApprovalClaim", "ReportUserApprovalClaim")
                        .WithOne("ReportUserSuggestedChanges")
                        .HasForeignKey("RegionReports.Data.Entities.ReportUserSuggestedChanges", "ReportUserApprovalClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelatedDistrict");

                    b.Navigation("ReportUserApprovalClaim");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.Region", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportUser", b =>
                {
                    b.Navigation("RelatedDistrict");

                    b.Navigation("UserApprovalClaims");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportUserApprovalClaim", b =>
                {
                    b.Navigation("ReportUserSuggestedChanges")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

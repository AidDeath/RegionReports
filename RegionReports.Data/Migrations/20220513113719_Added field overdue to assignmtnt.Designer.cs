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
    [Migration("20220513113719_Added field overdue to assignmtnt")]
    partial class Addedfieldoverduetoassignmtnt
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
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

            modelBuilder.Entity("RegionReports.Data.Entities.ReportAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateAssigned")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCancelledByOverDue")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ReportRequestSurveyId")
                        .HasColumnType("int");

                    b.Property<int?>("ReportRequestTextId")
                        .HasColumnType("int");

                    b.Property<int?>("ReportSurveyId")
                        .HasColumnType("int");

                    b.Property<int?>("ReportTextId")
                        .HasColumnType("int");

                    b.Property<int>("ReportUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportRequestSurveyId");

                    b.HasIndex("ReportRequestTextId");

                    b.HasIndex("ReportSurveyId")
                        .IsUnique()
                        .HasFilter("[ReportSurveyId] IS NOT NULL");

                    b.HasIndex("ReportTextId")
                        .IsUnique()
                        .HasFilter("[ReportTextId] IS NOT NULL");

                    b.HasIndex("ReportUserId");

                    b.ToTable("ReportAssignments");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportRequestFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FileOriginalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.Property<string>("FileUniqueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportRequestTextId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportRequestTextId");

                    b.ToTable("ReportRequestFiles");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportRequestSurvey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSchedulledRequest")
                        .HasColumnType("bit");

                    b.Property<bool>("MultipleChoises")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("NonScheduledDeadline")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReportScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("RequestText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReportScheduleId")
                        .IsUnique()
                        .HasFilter("[ReportScheduleId] IS NOT NULL");

                    b.ToTable("ReportRequestsSurvey");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportRequestSurveyOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportRequestSurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportRequestSurveyId");

                    b.ToTable("ReportRequestSurveyOptions");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportRequestText", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSchedulledRequest")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("NonScheduledDeadline")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReportScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("RequestText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReportScheduleId")
                        .IsUnique()
                        .HasFilter("[ReportScheduleId] IS NOT NULL");

                    b.ToTable("ReportRequestsText");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<short?>("DayOfMonth")
                        .HasColumnType("smallint");

                    b.Property<short?>("DayOfWeek")
                        .HasColumnType("smallint");

                    b.Property<int>("DaysBeforeAutoAssignment")
                        .HasColumnType("int");

                    b.Property<bool?>("IsScheduleActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("ScheduleType")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("ReportSchedules");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportSurvey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateFilled")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReportUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportUserId");

                    b.ToTable("ReportsSurvey");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportSurveyOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Checked")
                        .HasColumnType("bit");

                    b.Property<int>("ReportRequestSurveyOptionId")
                        .HasColumnType("int");

                    b.Property<int>("ReportSurveyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReportRequestSurveyOptionId");

                    b.HasIndex("ReportSurveyId");

                    b.ToTable("ReportSurveySelectableOptions");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportText", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateFilled")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReportUserId")
                        .HasColumnType("int");

                    b.Property<string>("RepsonseString")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReportUserId");

                    b.ToTable("ReportsText");
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

            modelBuilder.Entity("RegionReports.Data.Entities.UploadableFileType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlowedMimeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AlowedUploadFileTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlowedMimeType = "application/msword"
                        },
                        new
                        {
                            Id = 2,
                            AlowedMimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                        },
                        new
                        {
                            Id = 3,
                            AlowedMimeType = "application/vnd.ms-excel"
                        },
                        new
                        {
                            Id = 4,
                            AlowedMimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                        },
                        new
                        {
                            Id = 5,
                            AlowedMimeType = "application/pdf"
                        });
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

            modelBuilder.Entity("RegionReports.Data.Entities.ReportAssignment", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.ReportRequestSurvey", "ReportRequestSurvey")
                        .WithMany("ReportAssignments")
                        .HasForeignKey("ReportRequestSurveyId");

                    b.HasOne("RegionReports.Data.Entities.ReportRequestText", "ReportRequestText")
                        .WithMany("ReportAssignments")
                        .HasForeignKey("ReportRequestTextId");

                    b.HasOne("RegionReports.Data.Entities.ReportSurvey", "ReportSurvey")
                        .WithOne("ReportAssignment")
                        .HasForeignKey("RegionReports.Data.Entities.ReportAssignment", "ReportSurveyId");

                    b.HasOne("RegionReports.Data.Entities.ReportText", "ReportText")
                        .WithOne("ReportAssignment")
                        .HasForeignKey("RegionReports.Data.Entities.ReportAssignment", "ReportTextId");

                    b.HasOne("RegionReports.Data.Entities.ReportUser", "ReportUser")
                        .WithMany()
                        .HasForeignKey("ReportUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportRequestSurvey");

                    b.Navigation("ReportRequestText");

                    b.Navigation("ReportSurvey");

                    b.Navigation("ReportText");

                    b.Navigation("ReportUser");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportRequestFile", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.ReportRequestText", "RelatedReportText")
                        .WithMany("Files")
                        .HasForeignKey("ReportRequestTextId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RelatedReportText");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportRequestSurvey", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.ReportSchedule", "ReportSchedule")
                        .WithOne("ReportRequestSurvey")
                        .HasForeignKey("RegionReports.Data.Entities.ReportRequestSurvey", "ReportScheduleId");

                    b.Navigation("ReportSchedule");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportRequestSurveyOption", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.ReportRequestSurvey", "ReportRequestSurvey")
                        .WithMany("Options")
                        .HasForeignKey("ReportRequestSurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportRequestSurvey");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportRequestText", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.ReportSchedule", "ReportSchedule")
                        .WithOne("ReportRequestText")
                        .HasForeignKey("RegionReports.Data.Entities.ReportRequestText", "ReportScheduleId");

                    b.Navigation("ReportSchedule");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportSurvey", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.ReportUser", "ReportUser")
                        .WithMany()
                        .HasForeignKey("ReportUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportUser");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportSurveyOption", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.ReportRequestSurveyOption", "ReportRequestSurveyOption")
                        .WithMany()
                        .HasForeignKey("ReportRequestSurveyOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegionReports.Data.Entities.ReportSurvey", "ReportSurvey")
                        .WithMany("SelectableOptions")
                        .HasForeignKey("ReportSurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportRequestSurveyOption");

                    b.Navigation("ReportSurvey");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportText", b =>
                {
                    b.HasOne("RegionReports.Data.Entities.ReportUser", "ReportUser")
                        .WithMany()
                        .HasForeignKey("ReportUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("RegionReports.Data.Entities.ReportRequestSurvey", b =>
                {
                    b.Navigation("Options");

                    b.Navigation("ReportAssignments");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportRequestText", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("ReportAssignments");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportSchedule", b =>
                {
                    b.Navigation("ReportRequestSurvey");

                    b.Navigation("ReportRequestText");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportSurvey", b =>
                {
                    b.Navigation("ReportAssignment");

                    b.Navigation("SelectableOptions");
                });

            modelBuilder.Entity("RegionReports.Data.Entities.ReportText", b =>
                {
                    b.Navigation("ReportAssignment");
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

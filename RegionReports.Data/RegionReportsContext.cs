using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RegionReports.Data.Entities;

namespace RegionReports.Data
{
    public class RegionReportsContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<ReportUser> ReportUsers { get; set; }
        public DbSet<ReportUserApprovalClaim> ReportUserApprovalClaims { get; set; }
        public DbSet<ReportUserSuggestedChanges> ReportUserSuggestedChanges { get; set; }

        #region Survey Reports
        public DbSet<ReportRequestSurvey> ReportRequestsSurvey { get; set; }
        public DbSet<ReportRequestSurveyOption> ReportRequestSurveyOptions { get; set; }
        public DbSet<ReportSurvey> ReportsSurvey { get; set; }
        public DbSet<ReportSurveyOption> ReportSurveySelectedOptions { get; set; }
        #endregion


        private readonly IConfiguration _configuration;
        public RegionReportsContext(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MsSqlConnectionString"));
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RegionReport;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().Property(p => p.RegionName).IsRequired();
            modelBuilder.Entity<District>().Property(p => p.RegionId).IsRequired();
            modelBuilder.Entity<ReportUser>()
                .Property(p => p.WindowsUserName)
                    .IsRequired()
                    .HasDefaultValue(false);

            modelBuilder.Entity<ReportUser>()
                .HasMany(user => user.UserApprovalClaims)
                .WithOne(claim => claim.ReportUser)
                .HasForeignKey(claim => claim.ReportUserId);

            modelBuilder.Entity<Region>()
                .HasMany(region => region.Districts)
                .WithOne(district => district.Region)
                .HasForeignKey(district => district.RegionId);

            modelBuilder.Entity<ReportUser>()
                .HasOne(user => user.RelatedDistrict)
                .WithOne(district => district.ReportUser)
                .HasForeignKey<District>(district => district.ReportUserId);

            modelBuilder.Entity<ReportUserApprovalClaim>()
                 .HasOne(claim => claim.ReportUserSuggestedChanges)
                 .WithOne(changes => changes.ReportUserApprovalClaim)
                 .HasForeignKey<ReportUserSuggestedChanges>(changes => changes.ReportUserApprovalClaimId);

            modelBuilder.Entity<ReportUserSuggestedChanges>()
                .HasOne(changes => changes.RelatedDistrict)
                .WithMany()
                .HasForeignKey(changes => changes.RelatedDistrictId)
                .OnDelete(DeleteBehavior.NoAction);

            #region Survey Reports

            modelBuilder.Entity<ReportRequestSurvey>()
                .HasMany(repReq => repReq.Options)
                .WithOne(opt => opt.ReportRequestSurvey)
                .HasForeignKey(opt => opt.ReportRequestSurveyId);

            modelBuilder.Entity<ReportSurvey>()
                .HasMany(rep => rep.SelectedOptions)
                .WithOne(opt => opt.ReportSurvey)
                .HasForeignKey(opt => opt.ReportSurveyId);

            modelBuilder.Entity<ReportSurvey>()
                .HasOne(rep => rep.ReportUser)
                .WithMany()
                .HasForeignKey(rep => rep.ReportUserId);

            modelBuilder.Entity<ReportSurveyOption>()
                .HasOne(opt => opt.ReportRequestSurveyOption)
                .WithMany()
                .HasForeignKey(opt => opt.ReportRequestSurveyOptionId);
            #endregion





            modelBuilder.Entity<Region>().HasData(
                 new Region { Id= 1, RegionName = "Брестская область"},
                 new Region { Id= 2, RegionName = "Гродненская область"},
                 new Region { Id= 3, RegionName = "Витебская область"},
                 new Region { Id= 4, RegionName = "Могилевская область"},
                 new Region { Id= 5, RegionName = "Гомельская область"},
                 new Region { Id= 6, RegionName = "Минская область"}
                 );
            modelBuilder.Entity<District>().HasData(
                new District { Id = 1, RegionId = 6, DistrictName = "Березино" },
                new District { Id = 2, RegionId = 6, DistrictName = "Борисов" },
                new District { Id = 3, RegionId = 6, DistrictName = "Вилейка" },
                new District { Id = 4, RegionId = 6, DistrictName = "Воложин" },
                new District { Id = 5, RegionId = 6, DistrictName = "Дзержинск" },
                new District { Id = 6, RegionId = 6, DistrictName = "Жодино" },
                new District { Id = 7, RegionId = 6, DistrictName = "Клецк" },
                new District { Id = 8, RegionId = 6, DistrictName = "Копыль" },
                new District { Id = 9, RegionId = 6, DistrictName = "Крупки" },
                new District { Id = 10, RegionId = 6, DistrictName = "Логойск" },
                new District { Id = 11, RegionId = 6, DistrictName = "Любань" },
                new District { Id = 12, RegionId = 6, DistrictName = "Минск" },
                new District { Id = 13, RegionId = 6, DistrictName = "Молодечно" },
                new District { Id = 14, RegionId = 6, DistrictName = "Мядель" },
                new District { Id = 15, RegionId = 6, DistrictName = "Несвиж" },
                new District { Id = 16, RegionId = 6, DistrictName = "Пуховичи" },
                new District { Id = 17, RegionId = 6, DistrictName = "Слуцк" },
                new District { Id = 18, RegionId = 6, DistrictName = "Смолевичи" },
                new District { Id = 19, RegionId = 6, DistrictName = "Солигорск" },
                new District { Id = 20, RegionId = 6, DistrictName = "Старые Дороги" },
                new District { Id = 21, RegionId = 6, DistrictName = "Столбцы" },
                new District { Id = 22, RegionId = 6, DistrictName = "Узда" },
                new District { Id = 23, RegionId = 6, DistrictName = "Червень" }
                );
        }

        
    }
}
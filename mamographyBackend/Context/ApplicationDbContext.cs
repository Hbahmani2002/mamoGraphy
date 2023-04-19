using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace mamographyBackend.Context.user
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.SetCommandTimeout(10000);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<RPAC_UserLogin> RPAC_UserLogins { get; set; }
        public virtual DbSet<RPAC_UserHospitalPerson> RPAC_UserHospitalPeople { get; set; }
        public virtual DbSet<RPAC_Hospital> RPAC_Hospitals { get; set; }
        public virtual DbSet<RPAC_UserRole> RPAC_UserRoles { get; set; }
        public virtual DbSet<USR_UserHospitalPermission> USR_UserHospitalPermissions { get; set; }
        public virtual DbSet<RPAC_Report> RPAC_Reports { get; set; }
        public virtual DbSet<RPAC_Modality> RPAC_Modalities { get; set; }
        public virtual DbSet<RPAC_HospitalStudy> RPAC_HospitalStudies { get; set; }
        public virtual DbSet<RPAC_VW_PatientHL7Request> RPAC_VW_PatientHL7Requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("WebApiDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1254_CI_AS");

            modelBuilder.Entity<RPAC_UserLogin>(entity =>
            {
                entity.HasIndex(e => e.UserName, "IX_RPAC_UserLogin_UserName")
                    .IsUnique()
                    .HasFillFactor((byte)70);
            });
            modelBuilder.Entity<RPAC_UserHospitalPerson>(entity =>
            {
                entity.HasKey(e => e.UserLoginId)
                    .HasName("PK_RPAC_UserHospitalPerson_1");

                entity.HasComment("hastane kullanıcılari icin  bu tablo kullanılacak");

                entity.Property(e => e.UserLoginId).ValueGeneratedNever();
            });
            modelBuilder.Entity<RPAC_Hospital>(entity =>
            {
                entity.Property(e => e.NAPPacsAETitle).IsFixedLength(true);

                entity.Property(e => e.WadoUrl).IsFixedLength(true);
            });
            modelBuilder.Entity<USR_UserHospitalPermission>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.RecordState }, "IX_USR_UserHospitalPermission_UserId_RecordState")
                    .HasFillFactor((byte)70);
            });
            modelBuilder.Entity<RPAC_Report>(entity =>
            {
                entity.HasIndex(e => e.CreatedTime, "CreatedTime")
                    .HasFillFactor((byte)70);

                entity.HasIndex(e => new { e.CreatedTime, e.RecordState }, "IX_RPAC_Report_CreatedTime_RecordState_LastDays")
                    .HasFilter("([CreatedTime]>'2019-07-31')");

                entity.HasIndex(e => new { e.Id, e.CreatedTime }, "IX_RPAC_Report_ID")
                    .IsUnique()
                    .HasFilter("([CreatedTime]>'2019-07-31')");

                entity.HasIndex(e => new { e.IsConfirmed, e.RecordState, e.CreatedTime }, "IX_RPAC_Report_IsConfirmed_CreatedTime")
                    .HasFilter("([CreatedTime]>'2019-02-03')");

                entity.HasIndex(e => new { e.IsConfirmed, e.RecordState, e.ConfirmationTime }, "IX_RPAC_Report_IsConfirmed_RecordState_ConfirmationTime")
                    .HasFilter("([CreatedTime]>'2019-06-01')");

                entity.HasIndex(e => e.Id, "Id")
                    .HasFillFactor((byte)70);
            });
            modelBuilder.Entity<RPAC_HospitalStudy>(entity =>
            {
                entity.HasIndex(e => e.Id, "Id")
                    .HasFillFactor((byte)70);

                entity.HasIndex(e => e.HospitalId, "RPAC_HospitalStudy_HospitalId")
                    .HasFilter("([HospitalData_CreatedTime]>'2019-01-01')");

                entity.Property(e => e.HasVoicePath).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsConfirmed).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsRead).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsWritten).HasDefaultValueSql("((0))");

                entity.Property(e => e.RemainingEmergencyTime).HasComputedColumnSql("(case when [EmergencyTimeManual] IS NOT NULL then [EmergencyTimeManual]-datediff(minute,[EmergencyDate],getdate())  end)", false);

                entity.Property(e => e.RemainingRequestCount).HasComputedColumnSql("(case when ([requestCount]-[reportCount])<(0) then (0) else [requestCount]-[reportCount] end)", false);

                entity.Property(e => e.ReportCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.RequestCount).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<RPAC_VW_PatientHL7Request>(entity =>
            {
                entity.ToView("RPAC_VW_PatientHL7Request");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

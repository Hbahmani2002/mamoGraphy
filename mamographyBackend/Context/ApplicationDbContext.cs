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
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<RPAC_UserLogin> RPAC_UserLogins { get; set; }
        public virtual DbSet<RPAC_UserHospitalPerson> RPAC_UserHospitalPeople { get; set; }
        public virtual DbSet<RPAC_Hospital> RPAC_Hospitals { get; set; }
        public virtual DbSet<RPAC_UserRole> RPAC_UserRoles { get; set; }
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
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

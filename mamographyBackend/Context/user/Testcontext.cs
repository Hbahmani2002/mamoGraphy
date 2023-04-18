using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace mamographyBackend.Context.user
{
    public partial class Testcontext : DbContext
    {
        public Testcontext()
        {
        }

        public Testcontext(DbContextOptions<Testcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<USR_UserHospitalPermission> USR_UserHospitalPermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=85.95.242.213,14330;Initial Catalog=NAPPACSDB_Live;Integrated Security=False;Persist Security Info=False;User ID=nappacs_db;Password=Prot@k2020!!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<USR_UserHospitalPermission>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.RecordState }, "IX_USR_UserHospitalPermission_UserId_RecordState")
                    .HasFillFactor((byte)70);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

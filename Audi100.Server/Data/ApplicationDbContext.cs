using System.Collections.Generic;
using Audi100.Models;
using Microsoft.EntityFrameworkCore;

namespace Audi100.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        #region User
        public DbSet<User> User { get; set; }
        #endregion
        #region Audit
        public DbSet<AuditFinding> AuditFinding { get; set; }
        public DbSet<AuditReport> AuditReport { get; set; }
        public DbSet<AuditPrint> AuditPrint { get; set; }
        public DbSet<AuditTrail> AuditTrail { get; set; }
        #endregion

        #region Catalogs
        public DbSet<Bsc> Bsc { get; set; }
        public DbSet<Classification> Classification { get; set; }
        public DbSet<Weighing> WeightingClassification { get; set; }
        public DbSet<ShortF> ShortF { get; set; }
        public DbSet<Photo> Photo { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region User
            builder.Entity<User>()
                .OwnsOne(p => p.RecordLog);
            #endregion

            #region Audit
            builder.Entity<AuditFinding>()
                .OwnsOne(p => p.RecordLog);

            builder.Entity<AuditReport>()
                .OwnsOne(p => p.RecordLog);

            builder.Entity<AuditPrint>()
                .OwnsOne(p => p.RecordLog);            
            
            builder.Entity<AuditTrail>()
                .OwnsOne(p => p.RecordLog);
            #endregion

            #region Catalogs
            builder.Entity<Bsc>()
                .OwnsOne(p => p.RecordLog);

            builder.Entity<Classification>()
                .OwnsOne(p => p.RecordLog);

            builder.Entity<Weighing>()
                .OwnsOne(p => p.RecordLog);

            builder.Entity<ShortF>()
                .OwnsOne(p => p.RecordLog);

            builder.Entity<Photo>()
                .OwnsOne(p => p.RecordLog);
            #endregion
        }
    }
}

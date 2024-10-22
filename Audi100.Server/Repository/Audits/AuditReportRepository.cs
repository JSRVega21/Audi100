using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class AuditReportRepository : IRepository<AuditReport, int>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public AuditReportRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public AuditReport Add(AuditReport entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.AuditReport.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<AuditReport> AddAsync(AuditReport entity)
        {
            var db = _factory.CreateDbContext();
            db.AuditReport.Add(entity);
            await db.SaveChangesAsync();
            entity.GenerateReportCode();
            db.AuditReport.Update(entity);
            await db.SaveChangesAsync();

            return entity;
        }

        public void Delete(int key)
        {
            var db = _factory.CreateDbContext();
            AuditReport entity = db.AuditReport.Find(key);
            db.AuditReport.Remove(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int key)
        {
            var db = _factory.CreateDbContext();
            AuditReport entity = await db.AuditReport.FindAsync(key);
            db.AuditReport.Remove(entity);
            await db.SaveChangesAsync();
        }

        public AuditReport GetByKey(int key)
        {
            return GetByKey(key, true);
        }

        public AuditReport GetByKey(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.AuditReport.Find(key);
            }
            else
            {
                return db.AuditReport.AsNoTracking().FirstOrDefault(item => item.AuditReportId == key);
            }
        }

        public async Task<AuditReport> GetByKeyAsync(int key)
        {
            return await GetByKeyAsync(key, true);
        }

        public async Task<AuditReport> GetByKeyAsync(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.AuditReport.FindAsync(key);
            }
            else
            {
                return await db.AuditReport.AsNoTracking().FirstOrDefaultAsync(item => item.AuditReportId == key);
            }
        }

        public IList<AuditReport> GetList()
        {
            var db = _factory.CreateDbContext();
            return db.AuditReport.ToList();
        }

        public async Task<IList<AuditReport>> GetListAsync()
        {
            var db = _factory.CreateDbContext();
            return await db.AuditReport.ToListAsync();
        }

        public AuditReport Update(AuditReport entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }

        public async Task<AuditReport> UpdateAsync(AuditReport entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entity;
        }

    }
}

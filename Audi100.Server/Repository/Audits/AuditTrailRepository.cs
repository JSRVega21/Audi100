using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class AuditTrailRepository : IRepository<AuditTrail, int>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public AuditTrailRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public AuditTrail Add(AuditTrail entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.AuditTrail.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<AuditTrail> AddAsync(AuditTrail entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.AuditTrail.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void Delete(int key)
        {
            var db = _factory.CreateDbContext();
            AuditTrail entity = db.AuditTrail.Find(key);
            db.AuditTrail.Remove(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int key)
        {
            var db = _factory.CreateDbContext();
            AuditTrail entity = await db.AuditTrail.FindAsync(key);
            db.AuditTrail.Remove(entity);
            await db.SaveChangesAsync();
        }

        public AuditTrail GetByKey(int key)
        {
            return GetByKey(key, true);
        }

        public AuditTrail GetByKey(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.AuditTrail.Find(key);
            }
            else
            {
                return db.AuditTrail.AsNoTracking().FirstOrDefault(item => item.AuditTrailId == key);
            }
        }

        public async Task<AuditTrail> GetByKeyAsync(int key)
        {
            return await GetByKeyAsync(key, true);
        }

        public async Task<AuditTrail> GetByKeyAsync(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.AuditTrail.FindAsync(key);
            }
            else
            {
                return await db.AuditTrail.AsNoTracking().FirstOrDefaultAsync(item => item.AuditTrailId == key);
            }
        }

        public IList<AuditTrail> GetList()
        {
            var db = _factory.CreateDbContext();
            return db.AuditTrail.ToList();
        }

        public async Task<IList<AuditTrail>> GetListAsync()
        {
            var db = _factory.CreateDbContext();
            return await db.AuditTrail.ToListAsync();
        }

        public AuditTrail Update(AuditTrail entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }

        public async Task<AuditTrail> UpdateAsync(AuditTrail entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entity;
        }
    }
}

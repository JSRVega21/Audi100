using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class AuditFindingRepository : IRepository<AuditFinding, int>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public AuditFindingRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public AuditFinding Add(AuditFinding entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.AuditFinding.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<AuditFinding> AddAsync(AuditFinding entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.AuditFinding.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void Delete(int key)
        {
            var db = _factory.CreateDbContext();
            AuditFinding entity = db.AuditFinding.Find(key);
            db.AuditFinding.Remove(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int key)
        {
            var db = _factory.CreateDbContext();
            AuditFinding entity = await db.AuditFinding.FindAsync(key);
            db.AuditFinding.Remove(entity);
            await db.SaveChangesAsync();
        }

        public AuditFinding GetByKey(int key)
        {
            return GetByKey(key, true);
        }

        public AuditFinding GetByKey(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.AuditFinding.Find(key);
            }
            else
            {
                return db.AuditFinding.AsNoTracking().FirstOrDefault(item => item.AuditFindingId == key);
            }
        }

        public async Task<AuditFinding> GetByKeyAsync(int key)
        {
            return await GetByKeyAsync(key, true);
        }

        public async Task<AuditFinding> GetByKeyAsync(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.AuditFinding.FindAsync(key);
            }
            else
            {
                return await db.AuditFinding.AsNoTracking().FirstOrDefaultAsync(item => item.AuditFindingId == key);
            }
        }

        public IList<AuditFinding> GetList()
        {
            var db = _factory.CreateDbContext();
            return db.AuditFinding.ToList();
        }

        public async Task<IList<AuditFinding>> GetListAsync()
        {
            var db = _factory.CreateDbContext();
            return await db.AuditFinding.ToListAsync();
        }

        public AuditFinding Update(AuditFinding entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }

        public async Task<AuditFinding> UpdateAsync(AuditFinding entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entity;
        }
    }
}

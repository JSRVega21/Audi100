using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class AuditPrintRepository : IRepository<AuditPrint, int>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public AuditPrintRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public AuditPrint Add(AuditPrint entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.AuditPrint.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<AuditPrint> AddAsync(AuditPrint entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.AuditPrint.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void Delete(int key)
        {
            var db = _factory.CreateDbContext();
            AuditPrint entity = db.AuditPrint.Find(key);
            db.AuditPrint.Remove(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int key)
        {
            var db = _factory.CreateDbContext();
            AuditPrint entity = await db.AuditPrint.FindAsync(key);
            db.AuditPrint.Remove(entity);
            await db.SaveChangesAsync();
        }

        public AuditPrint GetByKey(int key)
        {
            return GetByKey(key, true);
        }

        public AuditPrint GetByKey(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.AuditPrint.Find(key);
            }
            else
            {
                return db.AuditPrint.AsNoTracking().FirstOrDefault(item => item.AuditPrintId == key);
            }
        }

        public async Task<AuditPrint> GetByKeyAsync(int key)
        {
            return await GetByKeyAsync(key, true);
        }

        public async Task<AuditPrint> GetByKeyAsync(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.AuditPrint.FindAsync(key);
            }
            else
            {
                return await db.AuditPrint.AsNoTracking().FirstOrDefaultAsync(item => item.AuditPrintId == key);
            }
        }

        public IList<AuditPrint> GetList()
        {
            var db = _factory.CreateDbContext();
            return db.AuditPrint.ToList();
        }

        public async Task<IList<AuditPrint>> GetListAsync()
        {
            var db = _factory.CreateDbContext();
            return await db.AuditPrint.ToListAsync();
        }

        public AuditPrint Update(AuditPrint entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }

        public async Task<AuditPrint> UpdateAsync(AuditPrint entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entity;
        }
    }
}


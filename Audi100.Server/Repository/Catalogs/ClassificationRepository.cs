using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class ClassificationRepository : IRepository<Classification, int>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public ClassificationRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public Classification Add(Classification entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.Classification.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<Classification> AddAsync(Classification entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.Classification.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void Delete(int key)
        {
            var db = _factory.CreateDbContext();
            Classification entity = db.Classification.Find(key);
            db.Classification.Remove(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int key)
        {
            var db = _factory.CreateDbContext();
            Classification entity = await db.Classification.FindAsync(key);
            db.Classification.Remove(entity);
            await db.SaveChangesAsync();
        }

        public Classification GetByKey(int key)
        {
            return GetByKey(key, true);
        }

        public Classification GetByKey(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.Classification.Find(key);
            }
            else
            {
                return db.Classification.AsNoTracking().FirstOrDefault(item => item.ClassificationId == key);
            }
        }

        public async Task<Classification> GetByKeyAsync(int key)
        {
            return await GetByKeyAsync(key, true);
        }

        public async Task<Classification> GetByKeyAsync(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.Classification.FindAsync(key);
            }
            else
            {
                return await db.Classification.AsNoTracking().FirstOrDefaultAsync(item => item.ClassificationId == key);
            }
        }

        public IList<Classification> GetList()
        {
            var db = _factory.CreateDbContext();
            return db.Classification.ToList();
        }

        public async Task<IList<Classification>> GetListAsync()
        {
            var db = _factory.CreateDbContext();
            return await db.Classification.ToListAsync();
        }

        public Classification Update(Classification entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
        public async Task<Classification> UpdateAsync(Classification entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entity;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class ShortFRepository : IRepository<ShortF, int>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public ShortFRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public ShortF Add(ShortF entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.ShortF.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<ShortF> AddAsync(ShortF entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.ShortF.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void Delete(int key)
        {
            var db = _factory.CreateDbContext();
            ShortF entity = db.ShortF.Find(key);
            db.ShortF.Remove(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int key)
        {
            var db = _factory.CreateDbContext();
            ShortF entity = await db.ShortF.FindAsync(key);
            db.ShortF.Remove(entity);
            await db.SaveChangesAsync();
        }

        public ShortF GetByKey(int key)
        {
            return GetByKey(key, true);
        }

        public ShortF GetByKey(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.ShortF.Find(key);
            }
            else
            {
                return db.ShortF.AsNoTracking().FirstOrDefault(item => item.ShortFId == key);
            }
        }

        public async Task<ShortF> GetByKeyAsync(int key)
        {
            return await GetByKeyAsync(key, true);
        }

        public async Task<ShortF> GetByKeyAsync(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.ShortF.FindAsync(key);
            }
            else
            {
                return await db.ShortF.AsNoTracking().FirstOrDefaultAsync(item => item.ShortFId == key);
            }
        }

        public IList<ShortF> GetList()
        {
            var db = _factory.CreateDbContext();
            return db.ShortF.ToList();
        }

        public async Task<IList<ShortF>> GetListAsync()
        {
            var db = _factory.CreateDbContext();
            return await db.ShortF.ToListAsync();
        }

        public ShortF Update(ShortF entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }

        public async Task<ShortF> UpdateAsync(ShortF entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entity;
        }
    }
}

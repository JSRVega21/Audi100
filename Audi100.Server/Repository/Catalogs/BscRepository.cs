using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class BscRepository : IRepository<Bsc, int>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public BscRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public Bsc Add(Bsc entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.Bsc.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<Bsc> AddAsync(Bsc entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.Bsc.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void Delete(int key)
        {
            var db = _factory.CreateDbContext();
            Bsc entity = db.Bsc.Find(key);
            db.Bsc.Remove(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int key)
        {
            var db = _factory.CreateDbContext();
            Bsc entity = await db.Bsc.FindAsync(key);
            db.Bsc.Remove(entity);
            await db.SaveChangesAsync();
        }

        public Bsc GetByKey(int key)
        {
            return GetByKey(key, true);
        }

        public Bsc GetByKey(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.Bsc.Find(key);
            }
            else
            {
                return db.Bsc.AsNoTracking().FirstOrDefault(item => item.BscId == key);
            }
        }

        public async Task<Bsc> GetByKeyAsync(int key)
        {
            return await GetByKeyAsync(key, true);
        }

        public async Task<Bsc> GetByKeyAsync(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.Bsc.FindAsync(key);
            }
            else
            {
                return await db.Bsc.AsNoTracking().FirstOrDefaultAsync(item => item.BscId == key);
            }
        }

        public IList<Bsc> GetList()
        {
            var db = _factory.CreateDbContext();
            return db.Bsc.ToList();
        }

        public async Task<IList<Bsc>> GetListAsync()
        {
            var db = _factory.CreateDbContext();
            return await db.Bsc.ToListAsync();
        }

        public Bsc Update(Bsc entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }

        public async Task<Bsc> UpdateAsync(Bsc entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entity;
        }
    }
}

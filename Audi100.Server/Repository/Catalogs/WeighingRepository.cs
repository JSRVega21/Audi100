using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class WeighingRepository : IRepository<Weighing, int>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public WeighingRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public Weighing Add(Weighing entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.WeightingClassification.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<Weighing> AddAsync(Weighing entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.WeightingClassification.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void Delete(int key)
        {
            var db = _factory.CreateDbContext();
            Weighing entity = db.WeightingClassification.Find(key);
            db.WeightingClassification.Remove(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int key)
        {
            var db = _factory.CreateDbContext();
            Weighing entity = await db.WeightingClassification.FindAsync(key);
            db.WeightingClassification.Remove(entity);
            await db.SaveChangesAsync();
        }

        public Weighing GetByKey(int key)
        {
            return GetByKey(key, true);
        }

        public Weighing GetByKey(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.WeightingClassification.Find(key);
            }
            else
            {
                return db.WeightingClassification.AsNoTracking().FirstOrDefault(item => item.WeighingId == key);
            }
        }

        public async Task<Weighing> GetByKeyAsync(int key)
        {
            return await GetByKeyAsync(key, true);
        }

        public async Task<Weighing> GetByKeyAsync(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.WeightingClassification.FindAsync(key);
            }
            else
            {
                return await db.WeightingClassification.AsNoTracking().FirstOrDefaultAsync(item => item.WeighingId == key);
            }
        }

        public IList<Weighing> GetList()
        {
            var db = _factory.CreateDbContext();
            return db.WeightingClassification.ToList();
        }

        public async Task<IList<Weighing>> GetListAsync()
        {
            var db = _factory.CreateDbContext();
            return await db.WeightingClassification.ToListAsync();
        }

        public Weighing Update(Weighing entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
        public async Task<Weighing> UpdateAsync(Weighing entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entity;
        }
    }
}

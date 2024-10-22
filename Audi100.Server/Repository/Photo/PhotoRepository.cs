using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class PhotoRepository : IPhotoRepository<Photo, int>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public PhotoRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public Photo Add(Photo entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.Photo.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<Photo> AddAsync(Photo entity)
        {
            var db = _factory.CreateDbContext();
            entity.Initialize();
            db.Photo.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void Delete(int key)
        {
            var db = _factory.CreateDbContext();
            Photo entity = db.Photo.Find(key);
            db.Photo.Remove(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int key)
        {
            var db = _factory.CreateDbContext();
            Photo entity = await db.Photo.FindAsync(key);
            db.Photo.Remove(entity);
            await db.SaveChangesAsync();
        }

        public Photo GetByKey(int key)
        {
            return GetByKey(key, true);
        }

        public Photo GetByKey(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.Photo.Find(key);
            }
            else
            {
                return db.Photo.AsNoTracking().FirstOrDefault(item => item.PhotoId == key);
            }
        }

        public async Task<Photo> GetByKeyAsync(int key)
        {
            return await GetByKeyAsync(key, true);
        }

        public async Task<Photo> GetByKeyAsync(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.Photo.FindAsync(key);
            }
            else
            {
                return await db.Photo.AsNoTracking().FirstOrDefaultAsync(item => item.PhotoId == key);
            }
        }

        public IList<Photo> GetList()
        {
            var db = _factory.CreateDbContext();
            return db.Photo.ToList();
        }

        public async Task<IList<Photo>> GetListAsync()
        {
            var db = _factory.CreateDbContext();
            return await db.Photo.ToListAsync();
        }

        public Photo Update(Photo entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }

        public async Task<Photo> UpdateAsync(Photo entity)
        {
            var db = _factory.CreateDbContext();
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return entity;
        }
        public IList<Photo> GetAuditId(int auditFindingId)
        {
            var db = _factory.CreateDbContext();
            return db.Photo.Where(photo => photo.AuditFindingId == auditFindingId).ToList();
        }

        public async Task<IList<Photo>> GetAuditIdAsync(int auditFindingId)
        {
            var db = _factory.CreateDbContext();
            return await db.Photo.Where(photo => photo.AuditFindingId == auditFindingId).ToListAsync();
        }
    }
}

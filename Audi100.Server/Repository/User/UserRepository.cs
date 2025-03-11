using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Audi100.Server.Data;
using Audi100.Models;

namespace Audi100.Server.Repository
{
    public class UserRepository : IUserRepository<User, int>
    {
        private readonly IDbContextFactory<ApplicationDbContext> _factory;
        public UserRepository(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }

        public User Add(User entity)
        {
            var db = _factory.CreateDbContext();
            entity.UserPassword = BCrypt.Net.BCrypt.HashPassword(entity.UserPassword);
            entity.Initialize();
            db.User.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<User> AddAsync(User entity)
        {
            var db = _factory.CreateDbContext();
            entity.UserPassword = BCrypt.Net.BCrypt.HashPassword(entity.UserPassword);
            entity.Initialize();
            db.User.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public void Delete(int key)
        {
            var db = _factory.CreateDbContext();
            User entity = db.User.Find(key);
            db.User.Remove(entity);
            db.SaveChanges();
        }

        public async Task DeleteAsync(int key)
        {
            var db = _factory.CreateDbContext();
            User entity = await db.User.FindAsync(key);
            db.User.Remove(entity);
            await db.SaveChangesAsync();
        }

        public User GetByKey(int key)
        {
            return GetByKey(key, true);
        }

        public User GetByKey(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            return tracking
                ? db.User.Find(key)
                : db.User.AsNoTracking().FirstOrDefault(u => u.UserId == key);
        }

        public async Task<User> GetByKeyAsync(int key)
        {
            return await GetByKeyAsync(key, true);
        }

        public async Task<User> GetByKeyAsync(int key, bool tracking = false)
        {
            var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.User.FindAsync(key);
            }
            else
            {
                return await db.User.AsNoTracking().FirstOrDefaultAsync(item => item.UserId == key);
            }
        }

        public IList<User> GetList()
        {
            var db = _factory.CreateDbContext();
            return db.User.ToList();
        }

        public async Task<IList<User>> GetListAsync()
        {
            var db = _factory.CreateDbContext();
            return await db.User.ToListAsync();
        }

        public User Update(User entity)
        {
            var db = _factory.CreateDbContext();
            entity.UserPassword = BCrypt.Net.BCrypt.HashPassword(entity.UserPassword);
            entity.Updated();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return entity;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            var db = _factory.CreateDbContext();
            var existingUser = await db.User.FindAsync(entity.UserId);

            if (existingUser == null)
                throw new Exception("Usuario no encontrado");

            // Solo actualiza la contraseña si se ha proporcionado una nueva
            if (!string.IsNullOrWhiteSpace(entity.UserPassword) &&
                entity.UserPassword != existingUser.UserPassword)
            {
                existingUser.UserPassword = BCrypt.Net.BCrypt.HashPassword(entity.UserPassword);
            }

            // Actualiza otros campos
            existingUser.UserName = entity.UserName;
            existingUser.UserEmail = entity.UserEmail;
            existingUser.UserPhone = entity.UserPhone;
            existingUser.UserRoleId = entity.UserRoleId;
            existingUser.UserRole = entity.UserRole;


            await db.SaveChangesAsync();
            return existingUser;
        }

        public ApplicationDbContext GetDbContext()
        {
            return _factory.CreateDbContext();
        }

    }
}

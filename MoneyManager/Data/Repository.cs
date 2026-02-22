using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MoneyManager.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AppDbContext _db;
        private DbSet<T> _set;

        public Repository(AppDbContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        async Task<List<T>> IRepository<T>.GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        async Task<T?> IRepository<T>.GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        async Task IRepository<T>.AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        async Task IRepository<T>.UpdateAsync(T entity)
        {
            _set.Update(entity);
            await _db.SaveChangesAsync();
        }

        async Task IRepository<T>.DeleteAsync(int id)
        {
            var entity = await _set.FindAsync(id);
            if (entity != null)
            {
                _set.Remove(entity);
                await _db.SaveChangesAsync();
            }
        }
    }
}

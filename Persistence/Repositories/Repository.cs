using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataContext _context;

        public Repository(DataContext context)
        {
            this._context = context;
        }

        #region synchronous methods
        public T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                          .AsQueryable()
                          .Where(predicate)
                          .AsQueryable();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T Remove(T entity)
        {
            return _context.Remove<T>(entity).Entity;
        }

        public T RemoveById(int id)
        {
            var entity = FindById(id);
            return Remove(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T FindByGuid(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public T RemoveByGuid(Guid id)
        {
            var entity = FindByGuid(id);
            return Remove(entity);
        }

        public T Update(T entity)
        {
            return _context.Update<T>(entity).Entity;
        }
        #endregion

        #region Async methods
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> result = await _context.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            EntityEntry<T> result = await Task.Run(() => _context.Set<T>().Update(entity));
            return result.Entity;
        }

        public async Task<T> FindByIdAsync(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            if (result != null)
            {
                return result;
            }
            return default;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                                 .AsQueryable()
                                 .Where(predicate)
                                 .ToListAsync();
        }

        public async Task<T> FindByGuidAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        #endregion
    }
}

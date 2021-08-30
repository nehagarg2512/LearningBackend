using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IRepository<T>
    {
        #region synchronous definitions

        T Add(T entity); 
        IQueryable<T> GetAll();
        int SaveChanges();
        T Update(T entity);
        T FindById(int id);
        T Remove(T entity);
        T RemoveById(int id);
        T FindByGuid(Guid id);
        T RemoveByGuid(Guid Id);
        void AddRange(IEnumerable<T> entities);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        #endregion

        #region Async definitions
        Task<T> AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<int> SaveChangesAsync();
        Task<T> FindByIdAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<T> FindByGuidAsync(Guid id);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        #endregion
    }
}

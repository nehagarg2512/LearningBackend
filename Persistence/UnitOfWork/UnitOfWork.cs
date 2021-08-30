using Persistence.Context;
using Persistence.Repositories;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public class UnitOfWork : IPersistenceUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IRepositoryFactory _repositoryFactory;

        public UnitOfWork(DataContext context, IRepositoryFactory repositoryFactory)
        {
            _context = context;
            _repositoryFactory = repositoryFactory;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> GetGenericRepository<T>() where T : class
        {
            return _repositoryFactory.Create<T>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public bool HasUnsavedChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}

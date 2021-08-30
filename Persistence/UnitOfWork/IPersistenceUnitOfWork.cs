using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public interface IPersistenceUnitOfWork : IUnitOfWork
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}


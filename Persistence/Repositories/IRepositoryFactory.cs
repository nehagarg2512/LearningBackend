using Persistence.Context;

namespace Persistence.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<T> Create<T>(DataContext context);
    }
}

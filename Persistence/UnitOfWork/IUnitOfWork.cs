using Persistence.Repositories;
using System;

namespace Persistence
{
    public interface IUnitOfWork: IDisposable
    {
        bool HasUnsavedChanges();
        IRepository<T> GetGenericRepository<T>() where T : class;
    }
}

using Domain;
using Persistence.Context;
using System;

namespace Persistence.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IRepository<T> Create<T>(DataContext context)
        { 
            if(typeof(EntityBase) != typeof(T).BaseType)
            {
                throw new Exception("Trying to create repository of non entity base");
            }

            Type type = typeof(Repository<>);
            Type genericType = type.MakeGenericType(typeof(T));
            return (IRepository<T>)Activator.CreateInstance(genericType, context);
        }
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.EventManager
{
    public interface IEventManager
    {
        Task Publish<T>(T notification, CancellationToken cancellationToken = default) where T: IEvent;
        Task Publish<T>(IEnumerable<T> notifications) where T : IEvent;
    }
}

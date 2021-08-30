using MediatR;

namespace Core.EventManager
{
    public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent> 
                                                      where TEvent : IDomainEvent
    {
    }
}

using MediatR;

namespace Core.EventManager
{
    public interface IIntegrationEventHandler<TEvent> : INotificationHandler<TEvent>
                                                        where TEvent : IIntegrationEvent
    {
    }
}

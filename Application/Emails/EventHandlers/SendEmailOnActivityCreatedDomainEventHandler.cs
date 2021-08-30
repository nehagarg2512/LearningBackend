using ApplicationShared.Activities.Events;
using Core.EventManager;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Emails.EventHandlers
{
    public class SendEmailOnActivityCreatedDomainEventHandler : IDomainEventHandler<ActivitiesRetreivedDomainEvent>
    {
        private readonly ILogger<SendEmailOnActivityCreatedDomainEventHandler> _logger;

        public SendEmailOnActivityCreatedDomainEventHandler(ILogger<SendEmailOnActivityCreatedDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ActivitiesRetreivedDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => _logger.LogInformation($"Activity with id: {notification.AcitvityId} got created and now we are sending an email"));
        }
    }
}

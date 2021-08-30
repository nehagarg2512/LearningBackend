using Core.EventManager;

namespace ApplicationShared.Activities.Events
{
    public class ActivitiesRetreivedDomainEvent: IDomainEvent
    {
        public ActivitiesRetreivedDomainEvent(int acitvityId)
        {
            AcitvityId = acitvityId;
        }

        public int AcitvityId { get; }
    }
}

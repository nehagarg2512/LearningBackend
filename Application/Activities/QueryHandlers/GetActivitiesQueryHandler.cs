using ApplicationShared.Activities.Events;
using ApplicationShared.Activities.Queries;
using Core.EventManager;
using Core.QueryManager;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Activities.QueryHandlers
{
    public class GetActivitiesQueryHandler : IQueryHandler<GetActivitiesQuery, List<Activity>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventManager _eventManager;

        public GetActivitiesQueryHandler(IUnitOfWork unitOfWork, 
                                        IEventManager eventManager)
        {
            _unitOfWork = unitOfWork;
            _eventManager = eventManager;
        }

        public async Task<List<Activity>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
        {

            List<Activity> activities = await _unitOfWork
                .GetGenericRepository<Activity>()
                .GetAll()
                .Include(x => x.ActivityCategory)
                .Include(x => x.ActivityCity)
                .ToListAsync();

            await _eventManager.Publish(new ActivitiesRetreivedDomainEvent(123));

            return activities;
        }
    }
}

using ApplicationShared.Activities.Queries;
using Core.QueryManager;
using Domain;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.QueryHandlers
{
    public class GetActivityByGuidQueryHandler : IQueryHandler<GetActivityByGuidQuery, Activity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActivityByGuidQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Activity> Handle(GetActivityByGuidQuery request, CancellationToken cancellationToken)
        {
            Guid id = Guid.Parse(request.Id);
            
            return await _unitOfWork
                .GetGenericRepository<Activity>()
                .FindByGuidAsync(id);
        }
    }
}

using ApplicationShared.Values.Queries;
using Core.QueryManager;
using Domain;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Values.QueryHandlers
{
    public class GetValueByGuidQueryHandler : IQueryHandler<GetValueByIdQuery, Value>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetValueByGuidQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Value> Handle(GetValueByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork
                .GetGenericRepository<Value>()
                .FindByIdAsync(request.Id);
        }
    }
}

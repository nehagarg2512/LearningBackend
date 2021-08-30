using ApplicationShared.Values;
using Core.QueryManager;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Values.QueryHandlers
{
    public class GetValuesQueryHandler : IQueryHandler<GetValuesQuery, List<Value>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetValuesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Value>> Handle(GetValuesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork
                .GetGenericRepository<Value>()
                .GetAll()
                .AsQueryable()
                .ToListAsync();
        }
    }
}

using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.QueryManager
{
    public interface IQueryManager
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
        Task<object> Send(object request, CancellationToken cancellationToken = default);
    }
}

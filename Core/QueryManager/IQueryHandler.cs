using MediatR;

namespace Core.QueryManager
{
    public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
                                                             where TRequest : IRequest<TResponse>
    {
    }
}

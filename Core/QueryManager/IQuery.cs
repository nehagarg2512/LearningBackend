using MediatR;

namespace Core.QueryManager
{
    public interface IQuery<T>: IRequest<T>
    {
    }
}

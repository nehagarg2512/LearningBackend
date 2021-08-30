using MediatR;

namespace Core.CommandManager
{
    public interface ICommandHandler<TCommand>: IRequestHandler<TCommand> where TCommand: ICommand
    {
    }
}

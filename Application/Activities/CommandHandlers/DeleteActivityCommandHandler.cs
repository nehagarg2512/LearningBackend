using ApplicationShared.Activities.Commands;
using Core.CommandManager;
using Domain;
using MediatR;
using Persistence.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.CommandHandlers
{
    public class DeleteActivityCommandHandler : ICommandHandler<DeleteActivityCommand>
    {
        private readonly IPersistenceUnitOfWork _persistenceUnitOfWork;

        public DeleteActivityCommandHandler(IPersistenceUnitOfWork persistenceUnitOfWork)
        {
            _persistenceUnitOfWork = persistenceUnitOfWork;
        }

        public async Task<Unit> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
        {
            _persistenceUnitOfWork
                .GetGenericRepository<Activity>()
                .RemoveByGuid(request.Id);
            
            bool success = await _persistenceUnitOfWork.SaveChangesAsync() > 0;

            if(success)
            {
                return Unit.Value;
            }

            throw new Exception("Problem deleting the activity");
        }
    }
}

using ApplicationShared.Activities.Commands;
using Common.Errors;
using Core.CommandManager;
using Domain;
using MediatR;
using Persistence.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.CommandHandlers
{
    public class CreateActivityCommandHandler : ICommandHandler<CreateActivityCommand>
    {
        private readonly IPersistenceUnitOfWork _persistenceUnitOfWork;

        public CreateActivityCommandHandler(IPersistenceUnitOfWork persistenceUnitOfWork)
        {
            _persistenceUnitOfWork = persistenceUnitOfWork;
        }

        public async Task<Unit> Handle(CreateActivityCommand commmand, CancellationToken cancellationToken)
        {
            if (commmand is null)
            {
                throw new ActivityNotSavedException("Create activity command is null.");
            }

            Activity activity = MapRequestToActivity(commmand);

            _persistenceUnitOfWork
                .GetGenericRepository<Activity>()
                .Add(activity);

            await _persistenceUnitOfWork.SaveChangesAsync();

            return Unit.Value;
        }

        private static Activity MapRequestToActivity(CreateActivityCommand request)
        {
            return new Activity
            {
                Id = request.Id,
                City = request.City,
                CreatedOn = DateTime.Now,
                Description = request.Description,
                OnDate = request.OnDate,
                Title = request.Title,
                Venue = request.Venue
            };
        }
    }
}

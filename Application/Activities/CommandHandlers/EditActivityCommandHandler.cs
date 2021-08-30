using ApplicationShared.Activities.Commands;
using Core.CommandManager;
using Domain;
using Factories.Activities;
using MediatR;
using Persistence.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities.CommandHandlers
{
    public class EditActivityCommandHandler : ICommandHandler<EditActivityCommand>
    {
        private readonly IPersistenceUnitOfWork _persistentUnitOfWork;
        private readonly IActivityFactory _activityFactory;

        public EditActivityCommandHandler(
            IPersistenceUnitOfWork persistentUnitOfWork,
            IActivityFactory activityFactory)
        {
            _persistentUnitOfWork = persistentUnitOfWork;
            _activityFactory = activityFactory;
        }

        public async Task<Unit> Handle(EditActivityCommand request, CancellationToken cancellationToken)
        {
            Activity activity = await _persistentUnitOfWork
                .GetGenericRepository<Activity>()
                .FindByGuidAsync(request.Id);

            _activityFactory.UpdateActivity(activity, request);

            if (!_persistentUnitOfWork.HasUnsavedChanges())
            {
                return Unit.Value;
            }

            var success = await _persistentUnitOfWork.SaveChangesAsync() > 0;

            if (success)
            {
                return Unit.Value;
            }

            throw new Exception("Problem with updating activity");
        }
    }
}

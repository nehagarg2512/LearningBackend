using Core.CommandManager;
using System;

namespace ApplicationShared.Activities.Commands
{
    public class DeleteActivityCommand : ICommand
    {
        public DeleteActivityCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}

using Core.CommandManager;
using System;

namespace ApplicationShared.Activities.Commands
{
    public class EditActivityCommand : ICommand
    {
        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime? OnDate { get; }
        public string City { get; }
        public string Venue { get; }

        public EditActivityCommand(Guid id,
            string title,
            string description,
            DateTime onDate,
            string city,
            string venue)
        {
            Id = id;
            Title = title;
            Description = description;
            OnDate = onDate;
            City = city;
            Venue = venue;
        }
    }
}

using ApplicationShared.Activities.Commands;
using AutoMapper;
using Domain;
using System;

namespace Factories.Activities
{
    public class ActivityFactory : IActivityFactory
    {
        private readonly IMapper _mapper;

        public ActivityFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Activity UpdateActivity(Activity destination, EditActivityCommand source)
        {
            if (source is null)
            {
                throw new NullReferenceException($"{nameof(EditActivityCommand)} is null");
            }

            destination.City = source.City ?? destination.City;
            destination.Description = source.Description ?? destination.Description;
            destination.OnDate = source.OnDate ?? destination.OnDate;
            destination.Title = source.Title ?? destination.Title;
            destination.Venue = source.Venue ?? destination.Venue;

            return destination;
        }
    }
}

using System;

namespace API.Api.Activities.Resources
{
    public class ActivityResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime OnDate { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public ActivityCityResponse ActivityCity { get; set; }
        public ActivityCategoryResponse ActivityCategory { get; set; }
    }
}

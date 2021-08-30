using System;

namespace Domain
{
    public class Activity : EntityBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime OnDate { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public string Venue { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ActivityCityId { get; set; }
        public ActivityCity ActivityCity { get; set; }
        public int? ActivityCategoryId { get; set; }
        public ActivityCategory ActivityCategory { get; set; }
    }
}

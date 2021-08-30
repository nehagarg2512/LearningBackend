using System;

namespace Models.InputModels
{
    public class ActivityInputModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime OnDate { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
    }
}

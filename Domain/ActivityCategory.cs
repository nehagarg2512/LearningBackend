using System.Collections.Generic;

namespace Domain
{
    public class ActivityCategory : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Activity> Activities { get; set; }
    }
}

using Core.QueryManager;
using Domain;

namespace ApplicationShared.Activities.Queries
{
    public class GetActivityByGuidQuery: IQuery<Activity>
    {
        public string Id { get; set; }
        
        public GetActivityByGuidQuery(string id)
        {
            Id = id;
        }
    }
}

using Core.QueryManager;
using Domain;

namespace ApplicationShared.Values.Queries
{
    public class GetValueByIdQuery: IQuery<Value>
    {
        public int Id { get; set; }
        public GetValueByIdQuery(int id)
        {
            Id = id;
        }
    }
}

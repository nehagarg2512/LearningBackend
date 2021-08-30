using ApplicationShared.Activities.Commands;
using Domain;

namespace Factories.Activities
{
    public interface IActivityFactory
    {
        Activity UpdateActivity(Activity destination, EditActivityCommand source);
    }
}

using FluentValidation;
using Models.InputModels;

namespace Validations.Activity.Command
{
    public class ActivityInputModelValidator: ControllerValidator<ActivityInputModel>
    {
        public ActivityInputModelValidator()
        {
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Venue).NotEmpty();
            RuleFor(x => x.OnDate).NotEmpty();
            RuleFor(x => x.Category).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}

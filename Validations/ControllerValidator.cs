using FluentValidation;

namespace Validations
{
    public abstract class ControllerValidator<T> : AbstractValidator<T>
    {
        public ControllerValidator()
        {
            RuleFor(x => x).NotNull();
        }
    }
}

using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColourValidator:AbstractValidator<Colour>
    {
        public ColourValidator()
        {
            RuleFor(x => x.ColourName).NotEmpty();
            RuleFor(x => x.ColourName).MinimumLength(2);
        }
    }
}
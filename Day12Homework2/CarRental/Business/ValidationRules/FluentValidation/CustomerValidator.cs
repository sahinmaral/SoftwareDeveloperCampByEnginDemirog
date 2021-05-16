using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.CarName).NotEmpty();
            RuleFor(x => x.BrandId).NotEmpty();
            RuleFor(x => x.ColourId).NotEmpty();
            RuleFor(x => x.DailyPrice).GreaterThan(0);
            RuleFor(x => x.CarName).MinimumLength(2);
        }
    }
}
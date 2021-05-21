using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImagesValidator:AbstractValidator<CarImages>
    {
        public CarImagesValidator()
        {
            RuleFor(x => x.CarId).NotEmpty();
        }
    }
}
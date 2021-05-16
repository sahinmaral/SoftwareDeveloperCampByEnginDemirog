using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty();
            RuleFor(x => x.UserPassword).NotEmpty();
            RuleFor(x => x.UserFirstName).NotEmpty();
            RuleFor(x => x.UserLastName).NotEmpty();
            RuleFor(x => x.UserEmail).Must(x=>x.Contains("@")).WithMessage("Emailinizin ");
        }
    }
}
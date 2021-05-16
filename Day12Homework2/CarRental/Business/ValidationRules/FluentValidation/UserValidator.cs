using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
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
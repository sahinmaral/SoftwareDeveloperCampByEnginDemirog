using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            
            
        }
    }
}
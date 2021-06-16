using FluentValidation;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator(ProjekatASPContext context)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Your first name is required.").DependentRules(() => 
            {
                RuleFor(x => x.FirstName).MinimumLength(3).MaximumLength(20).Matches("^[A-Z][a-z]").WithMessage("The format of first name isn't correct.");
            });

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Your last name is required.").DependentRules(() =>
            {
                RuleFor(x => x.LastName).MinimumLength(5).MaximumLength(20).Matches("^[A-Z][a-z]").WithMessage("The format of last name isn't correct.");
            });

            RuleFor(x => x.Email).NotEmpty().WithMessage("Your email is required.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.").DependentRules(() =>
            {
                RuleFor(x => x.Password).MinimumLength(6).Matches("^[a-z][0-9]").WithMessage("The format of password isn't correct.");
            });

            RuleFor(x => x.RoleId).Must(id => context.Roles.Any(x => x.Id == id)).WithMessage("Choosen role doesn't exist.");
        }
    }
}

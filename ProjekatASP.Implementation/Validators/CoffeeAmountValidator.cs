using FluentValidation;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class CoffeeAmountValidator : AbstractValidator<CoffeeAmountDto>
    {
        public CoffeeAmountValidator(ProjekatASPContext context)
        {
            RuleFor(x => x.AmountId).NotEmpty().WithMessage("You must pick the right amount for coffee.").DependentRules(() =>
            {
                RuleFor(x => x.AmountId).Must(amount => context.Amounts.Any(x => x.Id == amount)).WithMessage("You must choose amount that exists.");
            });
            RuleFor(x => x.Price).Must(price => price >= 100).WithMessage("Price must be greater or equal to 100");
        }
    }
}

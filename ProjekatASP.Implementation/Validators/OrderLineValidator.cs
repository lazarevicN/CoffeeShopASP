using FluentValidation;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class OrderLineValidator : AbstractValidator<OrderLineDto>
    {
        public OrderLineValidator(ProjekatASPContext context)
        {
            RuleFor(x => x.CoffeeId).Must(coffee => context.Coffees.Any(x => x.Id == coffee)).WithMessage("Coffee You picked doesn't exist.");
            RuleFor(x => x.AmountId).Must(amount => context.Amounts.Any(x => x.Id == amount)).WithMessage("Pack amount You picked doesn't exist.");
            RuleFor(x => x.Quantity).Must(x => x > 0).WithMessage("Quantity must be higher than 0.");

        }
    }
}

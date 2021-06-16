using FluentValidation;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class UpdateAmountValidator : AbstractValidator<AmountDto>
    {
        public UpdateAmountValidator(ProjekatASPContext context)
        {
            RuleFor(x => x.PackAmount).NotEmpty().WithMessage("Pack amount is required.").DependentRules(() =>
            {
                RuleFor(x => x.PackAmount).Must(x => x >= 100).WithMessage("Pack amount must be higher or equal to 100.");
                RuleFor(x => x.PackAmount).Must((amount, packAmount) => !context.Amounts.Any(x => x.PackAmount == packAmount && x.Id != amount.Id)).WithMessage("This pack amount already exists.");
            });
        }
    }
}

using FluentValidation;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class UpdateCoffeeValidator : AbstractValidator<CoffeeDto>
    {
        public UpdateCoffeeValidator(ProjekatASPContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name of coffee is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((coffee, name) => !context.Coffees.Any(x => x.Name == name && x.Id != coffee.Id)).WithMessage("Coffee with this name already exists.");
            });

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description of coffee is required.");

            RuleFor(x => x.BeanId).NotEmpty().WithMessage("Type of bean for coffee is required.").DependentRules(() =>
            {
                RuleFor(x => x.BeanId).Must(bean => context.Beans.Any(x => x.Id == bean)).WithMessage("You must choose type of bean that exists.");
            });

            RuleFor(x => x.OriginId).NotEmpty().WithMessage("Origin for coffee is required.").DependentRules(() =>
            {
                RuleFor(x => x.OriginId).Must(origin => context.Origins.Any(x => x.Id == origin)).WithMessage("You must choose origin that exists.");
            });

            RuleFor(x => x.CoffeeAmounts).NotEmpty().WithMessage("Pick amount for coffee.").DependentRules(() =>
            {
                RuleForEach(x => x.CoffeeAmounts).SetValidator(new CoffeeAmountValidator(context));
            });
        }
    }
}

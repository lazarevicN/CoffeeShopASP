using FluentValidation;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class CreateOriginValidator : AbstractValidator<OriginDto>
    {
        public CreateOriginValidator(ProjekatASPContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Coffee origin name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(name => !context.Origins.Any(x => x.Name == name)).WithMessage("Coffee origin name already exists. Write new one!");
            });
        }
    }
}

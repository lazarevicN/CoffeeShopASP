using FluentValidation;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class CreateBeanValidator : AbstractValidator<BeanDto>
    {
        public CreateBeanValidator(ProjekatASPContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Type of Bean name is required.").DependentRules(() =>
            {
               RuleFor(x => x.Name).Must(name => !context.Beans.Any(x => x.Name == name)).WithMessage("Bean name already exists. Write new one!");
            });
        }
    }
}

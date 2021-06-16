using FluentValidation;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Validators
{
    public class UpdateBeanValidator : AbstractValidator<BeanDto>
    {
        public UpdateBeanValidator(ProjekatASPContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name of the type of coffee bean is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((bean, name) => !context.Beans.Any(x => x.Name == name && x.Id != bean.Id)).WithMessage("Coffee bean with this name already exists.");
            });

        }
    }
}

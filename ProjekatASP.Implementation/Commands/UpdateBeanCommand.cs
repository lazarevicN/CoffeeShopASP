using FluentValidation;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class UpdateBeanCommand : IUpdateBeanCommand
    {
        private readonly ProjekatASPContext _context;
        private readonly UpdateBeanValidator _validator;

        public UpdateBeanCommand(ProjekatASPContext context, UpdateBeanValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Updating type of coffee bean.";

        public void Execute(BeanDto request)
        {
            _validator.ValidateAndThrow(request);

            var bean = _context.Beans.Find(request.Id);

            if(bean == null)
            {
                throw new EntityNotFoundException(typeof(Bean));
            }

            bean.Name = request.Name;
            bean.ModifiedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}

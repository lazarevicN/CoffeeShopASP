using FluentValidation;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class UpdateOriginCommand : IUpdateOriginCommand
    {
        private readonly ProjekatASPContext _context;
        private readonly UpdateOriginValidator _validator;

        public UpdateOriginCommand(ProjekatASPContext context, UpdateOriginValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 7;

        public string Name => "Updating origin.";

        public void Execute(OriginDto request)
        {
            _validator.ValidateAndThrow(request);

            var origin = _context.Origins.Find(request.Id);

            if(origin == null)
            {
                throw new EntityNotFoundException(typeof(Origin));
            }

            origin.Name = request.Name;
            origin.ModifiedAt = DateTime.UtcNow;

            _context.SaveChanges();

        }
    }
}

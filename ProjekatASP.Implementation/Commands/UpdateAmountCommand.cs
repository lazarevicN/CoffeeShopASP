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
    public class UpdateAmountCommand : IUpdateAmountCommand
    {
        private readonly ProjekatASPContext _context;
        private readonly UpdateAmountValidator _validator;

        public UpdateAmountCommand(ProjekatASPContext context, UpdateAmountValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 11;

        public string Name => "Updating pack amount.";

        public void Execute(AmountDto request)
        {
            _validator.ValidateAndThrow(request);

            var amount = _context.Amounts.Find(request.Id);

            if(amount == null)
            {
                throw new EntityNotFoundException(typeof(Amount));
            }

            amount.PackAmount = request.PackAmount;
            amount.ModifiedAt = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}

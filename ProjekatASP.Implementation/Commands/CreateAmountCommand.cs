using AutoMapper;
using FluentValidation;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class CreateAmountCommand : ICreateAmountCommand
    {
        private readonly ProjekatASPContext _context;
        private readonly IMapper _mapper;
        private readonly CreateAmountValidator _validator;

        public CreateAmountCommand(ProjekatASPContext context, IMapper mapper, CreateAmountValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "Creating new amount of package for coffees.";

        public void Execute(AmountDto request)
        {
            _validator.ValidateAndThrow(request);

            var amount = _mapper.Map<Amount>(request);
            _context.Amounts.Add(amount);
            _context.SaveChanges();
        }
    }
}

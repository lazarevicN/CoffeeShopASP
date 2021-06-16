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
    public class CreateOriginCommand : ICreateOriginCommand
    {

        private readonly ProjekatASPContext _context;
        private readonly IMapper _mapper;
        private readonly CreateOriginValidator _validator;

        public CreateOriginCommand(ProjekatASPContext context, IMapper mapper, CreateOriginValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Creating new coffee origin.";

        public void Execute(OriginDto request)
        {
            _validator.ValidateAndThrow(request);

            var origin = _mapper.Map<Origin>(request);
            _context.Origins.Add(origin);
            _context.SaveChanges();
        }
    }
}

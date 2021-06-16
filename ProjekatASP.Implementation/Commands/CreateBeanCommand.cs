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
    public class CreateBeanCommand : ICreateBeanCommand
    {

        private readonly ProjekatASPContext _context;
        private readonly IMapper _mapper;
        private readonly CreateBeanValidator _validator;

        public CreateBeanCommand(ProjekatASPContext context, IMapper mapper, CreateBeanValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 2;

        public string Name => "Creating new type of coffee bean.";

        public void Execute(BeanDto request)
        {
            _validator.ValidateAndThrow(request);
            var bean = _mapper.Map<Bean>(request);
            _context.Beans.Add(bean);
            _context.SaveChanges();
        }
    }
}

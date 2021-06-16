using FluentValidation;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class CreateCoffeeCommand : ICreateCoffeeCommand
    {
        private readonly ProjekatASPContext _context;
        private readonly CreateCoffeeValidator _validator;

        public CreateCoffeeCommand(ProjekatASPContext context, CreateCoffeeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 14;

        public string Name => "Creating new coffee.";

        public void Execute(CoffeeDto request)
        {
            _validator.ValidateAndThrow(request);

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);
            var newImageName = guid + extension;

            var coffee = new Coffee
            {
                Name = request.Name,
                Description = request.Description,
                Image = newImageName,
                OriginId = request.OriginId,
                BeanId = request.BeanId,
                CoffeeAmounts = request.CoffeeAmounts.Select(x =>
                {
                    return new CoffeeAmount
                    {
                        AmountId = x.AmountId,
                        Price = x.Price
                    };
                }).ToList()
            };

            _context.Coffees.Add(coffee);
            _context.SaveChanges();
        }
    }
}

using FluentValidation;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Application.Exceptions;
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
    public class UpdateCoffeeCommand : IUpdateCoffeeCommand
    {
        private readonly ProjekatASPContext _context;
        private readonly UpdateCoffeeValidator _validator;

        public UpdateCoffeeCommand(ProjekatASPContext context, UpdateCoffeeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 15;

        public string Name => "Updating coffee.";

        public void Execute(CoffeeDto request)
        {
            _validator.ValidateAndThrow(request);

            var coffee = _context.Coffees.Find(request.Id);

            if(coffee == null)
            {
                throw new EntityNotFoundException(typeof(Coffee));
            }

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);
            var newImage = guid + extension;

            coffee.Name = request.Name;
            coffee.Description = request.Description;
            coffee.Image = newImage;
            coffee.BeanId = request.BeanId;
            coffee.OriginId = request.OriginId;
            coffee.CoffeeAmounts = request.CoffeeAmounts.Select(x =>
            {
                return new CoffeeAmount
                {
                    AmountId = x.AmountId,
                    Price = x.Price
                };
            }).ToList();

            coffee.ModifiedAt = DateTime.UtcNow;
            _context.SaveChanges();

        }
    }
}

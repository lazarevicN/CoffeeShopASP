using FluentValidation;
using ProjekatASP.Application;
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
    public class CreateOrderCommand : ICreateOrderCommand
    {
        private readonly ProjekatASPContext _context;
        private readonly CreateOrderValidator _validator;
        private readonly IApplicationActor _actor;

        public CreateOrderCommand(ProjekatASPContext context, CreateOrderValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 17;

        public string Name => "Creating coffee order.";

        public void Execute(OrderDto request)
        {
            _validator.ValidateAndThrow(request);

            var order = new Order
            {
                Address = request.Address,
                DateOfOrder = DateTime.UtcNow,
                UserId = _actor.Id,
                OrderLines = request.OrderLines.Select(x =>
                {
                    var coffee = _context.Coffees.Find(x.CoffeeId);

                    if (coffee == null)
                    {
                        throw new EntityNotFoundException(typeof(Coffee));
                    }

                    var coffeeAmount = _context.CoffeeAmounts.Where(c => c.CoffeeId == x.CoffeeId).Where(c => c.AmountId == x.AmountId).First();

                    if (coffeeAmount == null)
                    {
                        throw new EntityNotFoundException(typeof(Coffee));
                    }

                    return new OrderLine
                    {
                        CoffeeName = coffee.Name,
                        Quantity = x.Quantity,
                        CoffeeAmountId = coffeeAmount.Id,
                        Price = coffeeAmount.Price
                    };
                }).ToList()
            };

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}

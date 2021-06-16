using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class DeleteCoffeeCommand : IDeleteCoffeeCommand
    {
        private readonly ProjekatASPContext _context;

        public DeleteCoffeeCommand(ProjekatASPContext context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Deleting choosen coffee";        

        public void Execute(int request)
        {
            var coffee = _context.Coffees.Find(request);

            if(coffee == null)
            {
                throw new EntityNotFoundException(typeof(Coffee));
            }

            coffee.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}

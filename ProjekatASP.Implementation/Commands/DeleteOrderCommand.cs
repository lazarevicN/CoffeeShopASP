using ProjekatASP.Application.Commands;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class DeleteOrderCommand : IDeleteOrderCommand
    {
        private readonly ProjekatASPContext _context;

        public DeleteOrderCommand(ProjekatASPContext context)
        {
            _context = context;
        }

        public int Id => 19;

        public string Name => "Deleting choosen order.";

        public void Execute(int request)
        {
            var order = _context.Orders.Find(request);

            if(order == null)
            {
                throw new EntityNotFoundException(typeof(Order));
            }

            order.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}

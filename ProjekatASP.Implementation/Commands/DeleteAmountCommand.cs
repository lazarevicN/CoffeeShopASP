using ProjekatASP.Application.Commands;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class DeleteAmountCommand : IDeleteAmountCommand
    {
        private readonly ProjekatASPContext _context;

        public DeleteAmountCommand(ProjekatASPContext context)
        {
            _context = context;
        }

        public int Id => 12;

        public string Name => "Deleting choosen pack amount.";

        public void Execute(int request)
        {
            var amount = _context.Amounts.Find(request);

            if(amount == null)
            {
                throw new EntityNotFoundException(typeof(Amount));
            }

            amount.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}

using ProjekatASP.Application.Commands;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class DeleteOriginCommand : IDeleteOriginCommand
    {
        private readonly ProjekatASPContext _context;

        public DeleteOriginCommand(ProjekatASPContext context)
        {
            _context = context;
        }

        public int Id => 8;

        public string Name => "Deleting choosen coffee origin.";

        public void Execute(int request)
        {
            var origin = _context.Origins.Find(request);

            if(origin == null)
            {
                throw new EntityNotFoundException(typeof(Origin));
            }

            origin.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}

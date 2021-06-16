using ProjekatASP.Application.Commands;
using ProjekatASP.Application.Exceptions;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class DeleteBeanCommand : IDeleteBeanCommand
    {
        private readonly ProjekatASPContext _context;

        public DeleteBeanCommand(ProjekatASPContext context)
        {
            _context = context;
        }

        public int Id => 4;

        public string Name => "Deleting specific type of coffee bean.";

        public void Execute(int request)
        {
            var bean = _context.Beans.Find(request);

            if(bean == null)
            {
                throw new EntityNotFoundException(typeof(Bean));
            }

            bean.DeletedAt = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}

using Newtonsoft.Json;
using ProjekatASP.Application;
using ProjekatASP.Application.Interfaces;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly ProjekatASPContext _context;

        public DatabaseUseCaseLogger(ProjekatASPContext conext)
        {
            _context = conext;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object data)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                UserId = actor.Id,
                UseCaseName = useCase.Name,
                Email = actor.Email,
                Date = DateTime.UtcNow,
                Data = JsonConvert.SerializeObject(data)
            });

            _context.SaveChanges();
        }
    }
}

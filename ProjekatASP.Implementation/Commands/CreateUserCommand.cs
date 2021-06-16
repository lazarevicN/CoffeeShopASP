using FluentValidation;
using ProjekatASP.Application.Commands;
using ProjekatASP.Application.DataTransferObjects;
using ProjekatASP.Application.Interfaces.Email;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;
using ProjekatASP.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjekatASP.Implementation.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly ProjekatASPContext _context;
        private readonly IEmailSender _sender;
        private readonly CreateUserValidator _validator;

        public CreateUserCommand(ProjekatASPContext context, IEmailSender sender, CreateUserValidator validator)
        {
            _context = context;
            _sender = sender;
            _validator = validator;
        }

        public int Id => 21;

        public string Name => "Creating new user.";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var role = _context.Roles.FirstOrDefault(x => x.Name == "User");

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                RoleId = role.Id
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                SendTo = user.Email,
                Subject = "Registration for Coffee Shop",
                Content = "Some content about Your registration"
            });
            
        }
    }
}

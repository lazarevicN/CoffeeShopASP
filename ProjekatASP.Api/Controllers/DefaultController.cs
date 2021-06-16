using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatASP.Domain;
using ProjekatASP.EfDataAccess;

namespace ProjekatASP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ProjekatASPContext _context;

        public DefaultController(ProjekatASPContext context)
        {
            _context = context;
        }

        //Controller for first insert in DB
        // POST: api/Default
        [HttpPost]
        public void Post()
        {
            var beans = new List<Bean>
            {
                new Bean
                {
                    Name = "Arabica"
                },
                new Bean
                {
                    Name = "Robusta"
                },
                new Bean
                {
                    Name = "Liberica"
                },
                new Bean
                {
                    Name = "Excelsa"
                }
            };

            var origins = new List<Origin>
            {
                new Origin
                {
                    Name = "Brazil"
                },
                new Origin
                {
                    Name = "Vietnam"
                },
                new Origin
                {
                    Name = "Columbia"
                },
                new Origin
                {
                    Name = "Indonesia"
                },
                new Origin
                {
                    Name = "Ethiopia"
                }
            };

            var coffees = new List<Coffee>
            {
                new Coffee
                {
                    Name = "Ethiopian Lion",
                    Description = "Description 1",
                    Image = "",
                    Bean = beans.ElementAt(0),
                    Origin = origins.ElementAt(4)
                },
                new Coffee
                {
                    Name = "Serrano Lavado",
                    Description = "Description 2",
                    Image = "",
                    Bean = beans.ElementAt(1),
                    Origin = origins.ElementAt(2)
                },
                new Coffee
                {
                    Name = "Black Diamond",
                    Description = "Description 3",
                    Image = "",
                    Bean = beans.ElementAt(0),
                    Origin = origins.ElementAt(0)
                },
                new Coffee
                {
                    Name = "Night Blend",
                    Description = "Description 4",
                    Image = "",
                    Bean = beans.ElementAt(2),
                    Origin = origins.ElementAt(2)
                },
                new Coffee
                {
                    Name = "Maragogype",
                    Description = "Description 5",
                    Image = "",
                    Bean = beans.ElementAt(3),
                    Origin = origins.ElementAt(3)
                },
                new Coffee
                {
                    Name = "Cruz Grande",
                    Description = "Description 6",
                    Image = "",
                    Bean = beans.ElementAt(0),
                    Origin = origins.ElementAt(1)
                },
                new Coffee
                {
                    Name = "Supremo",
                    Description = "Description 7",
                    Image = "",
                    Bean = beans.ElementAt(0),
                    Origin = origins.ElementAt(2)
                },
                new Coffee
                {
                    Name = "Brazilian Tiger",
                    Description = "Description 8",
                    Image = "",
                    Bean = beans.ElementAt(0),
                    Origin = origins.ElementAt(0)
                },
            };

            var amounts = new List<Amount>
            {
                new Amount
                {
                    PackAmount = 250
                },
                new Amount
                {
                    PackAmount = 1000
                }
            };

            var coffeeAmounts = new List<CoffeeAmount>
            {
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(0),
                    Amount = amounts.ElementAt(0),
                    Price = 220
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(0),
                    Amount = amounts.ElementAt(1),
                    Price = 240
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(1),
                    Amount = amounts.ElementAt(0),
                    Price = 220
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(1),
                    Amount = amounts.ElementAt(1),
                    Price = 250
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(2),
                    Amount = amounts.ElementAt(0),
                    Price = 250
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(2),
                    Amount = amounts.ElementAt(1),
                    Price = 280
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(3),
                    Amount = amounts.ElementAt(1),
                    Price = 260
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(4),
                    Amount = amounts.ElementAt(1),
                    Price = 240
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(5),
                    Amount = amounts.ElementAt(0),
                    Price = 210
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(5),
                    Amount = amounts.ElementAt(1),
                    Price = 230
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(6),
                    Amount = amounts.ElementAt(0),
                    Price = 245
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(6),
                    Amount = amounts.ElementAt(1),
                    Price = 290
                },
                new CoffeeAmount
                {
                    Coffee = coffees.ElementAt(7),
                    Amount = amounts.ElementAt(0),
                    Price = 300
                }
            };


            var roles = new List<Role>
            {
                new Role
                {
                    Name = "Admin"
                },
                new Role
                {
                    Name = "User"
                }
            };

            var users = new List<User>
            {
                new User
                {
                    FirstName = "Nikola",
                    LastName = "Lazarevic",
                    Email = "lazarevic@gmail.com",
                    Password = "sifra123",
                    Role = roles.ElementAt(0)
                },
                new User
                {
                    FirstName = "Pera",
                    LastName = "Peric",
                    Email = "peric@gmail.com",
                    Password = "sifra1",
                    Role = roles.ElementAt(1)
                }
            };

            _context.Beans.AddRange(beans);
            _context.Origins.AddRange(origins);
            _context.Amounts.AddRange(amounts);
            _context.Coffees.AddRange(coffees);
            _context.CoffeeAmounts.AddRange(coffeeAmounts);
            _context.Roles.AddRange(roles);
            _context.Users.AddRange(users);

            _context.SaveChanges();
        }
    }
}

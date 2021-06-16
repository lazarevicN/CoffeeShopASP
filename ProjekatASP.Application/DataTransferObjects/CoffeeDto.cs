using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.DataTransferObjects
{
    public class CoffeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
        public int BeanId { get; set; }
        public int OriginId { get; set; }
        public IEnumerable<CoffeeAmountDto> CoffeeAmounts { get; set; } = new List<CoffeeAmountDto>();
    }

    public class CoffeeAmountDto
    {
        public int AmountId { get; set; }
        public decimal Price { get; set; }
    }
}

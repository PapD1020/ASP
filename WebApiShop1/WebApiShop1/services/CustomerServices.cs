using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiShop1.Models;

namespace WebApiShop1.services
{
    public class CustomerServices
    {
        private readonly rendelesContext context;

        public CustomerServices(rendelesContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProductsByUserId(int id)
        {
            
        }
    }
}

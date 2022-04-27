using System.Collections.Generic;
using System.Linq;
using WebApiShop1.Models;

namespace WebApiShop1.services
{
    public class OrderServices
    {
        private readonly rendelesContext context;

        public OrderServices(rendelesContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetUserOrderProducts(int customerId)
        {
            return context.OrdersProducts.Where(op => op.Orders.CustomerId == customerId).Select(op => op.P);
        }
    }
}

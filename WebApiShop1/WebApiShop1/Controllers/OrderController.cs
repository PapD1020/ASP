using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiShop1.services;

namespace WebApiShop1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderServices orderServices;

        public OrderController(OrderServices orderServices)
        {
            this.orderServices = orderServices;
        }

        [HttpGet]
        [Route("{customerId}")]
        public IEnumerab<Product> 
    }
}

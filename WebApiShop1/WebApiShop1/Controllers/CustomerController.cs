using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiShop1.Models;
using WebApiShop1.services;

namespace WebApiShop1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerServices customerServices;

        public CustomerController(CustomerServices customerServices)
        {
            this.customerServices = customerServices;
        }

        [HttpGet]
        [Route("{id}")]
        public IEnumerable<Product> GetAllProductsByCustomer(int id){
            return customerServices.GetProductsByUserId(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Models;
using MiPrimeraApi.Repository;

namespace MiPrimeraApi.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet(Name = "GetAllProductos")]
        public List<Product> GetAllProducts()
        {
            return ProductHandler.GetAllProductos(); 
        }

    }
}

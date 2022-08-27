using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Controllers.DTOS;
using MiPrimeraApi.Models;
using MiPrimeraApi.Repository;

namespace MiPrimeraApi.Controllers
{
        [ApiController]
        [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet(Name = "GetAllProductos")]
        public List<Product> GetAllProducts(int id)
        {
            return ProductHandler.GetAllProductos(id); 
        }




        [HttpPost]
        public bool CreateNewProduct([FromBody] PostProduct product)
        {
            return ProductHandler.CreateNewProduct(new Product
            {
                Description = product.Description,
                Cost = product.Cost,
                SalesPrice = product.SalesPrice,
                Stock = product.Stock,
                IdUser = product.IdUser,
            });

        }


        [HttpPut]
        public bool ModifideProduct([FromBody] PutProduct product)
        {
            return ProductHandler.ChangeProduct(new Product
            {
                Description = product.Description,
                Cost = product.Cost,
                SalesPrice = product.SalesPrice,
                Stock = product.Stock
            });
        }




        [HttpDelete]
        public bool DeleteProduct([FromBody] int id)
        {
            return ProductHandler.DeleteProduct(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Controllers.DTOS;
using MiPrimeraApi.Models;
using MiPrimeraApi.Repository;


namespace MiPrimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductSoldController :ControllerBase
    {
        [HttpGet("/api/[controller]/[action]")]
        public List<Product> GetSoldProductsByUser(int idUser)
        {
            return SoldProductHandler.GetSoldProductsByUser(idUser);
        }

    }
}

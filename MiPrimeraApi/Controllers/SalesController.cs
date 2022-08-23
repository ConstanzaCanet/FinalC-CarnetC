using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Models;
using MiPrimeraApi.Repository;

namespace MiPrimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController
    {
        [HttpGet("GetAllSales")]
        public List<Sale> GetAllSales()
        {
            return SalesHandler.GetAllSales();
        }
    }
}

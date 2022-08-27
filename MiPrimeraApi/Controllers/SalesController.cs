﻿using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi.Controllers.DTOS;
using MiPrimeraApi.Models;
using MiPrimeraApi.Repository;

namespace MiPrimeraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController
    {
        [HttpGet("GetAllSales")]
        public List<Sale> GetAllSales(int idUser)
        {
            return SalesHandler.GetProductosVendidos(idUser);
        }


        [HttpPut("ChangeComentsSales")]
        public bool ChangeComent([FromBody] PutSales comentNew)
        {
            return SalesHandler.ChangeComent(new Sale
            {
                Id = comentNew.Id,
                coments = comentNew.coments
            });
        }
    }
}

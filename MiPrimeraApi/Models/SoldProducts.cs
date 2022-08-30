using System;
namespace MiPrimeraApi.Models
{
    public class SoldProduct
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Stock { get; set; }
        public int IdSale { get; set; }

        public SoldProduct()
        {
            Id = 0;
            IdProduct = 0;
            Stock = 0;
            IdSale = 0;
        }

        public SoldProduct(int id, int idProduct, int stock, int idSale)
        {
            this.Id = id;
            this.IdProduct = idProduct;
            this.Stock = stock;
            this.IdSale = idSale;
        }


    }
}

namespace MiPrimeraApi.Models
{
    public class soldProduct
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Stock { get; set; }
        public int IdSale { get; set; }

        public soldProduct()
        {
            Id = 0;
            IdProduct = 0;
            Stock = 0;
            IdSale = 0;
        }

        public soldProduct(int id, int idProduct, int stock, int idSale)
        {
            this.Id = id;
            this.IdProduct = idProduct;
            this.Stock = stock;
            this.IdSale = idSale;
        }


    }
}

namespace MiPrimeraApi.Controllers.DTOS
{
    public class PostSoldProduct
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Stock { get; set; }
        public int IdSale { get; set; }
    }
}

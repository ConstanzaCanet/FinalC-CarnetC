namespace MiPrimeraApi.Controllers.DTOS
{
    public class PostProduct
    {
        public string Description { get; set; }
        public int Cost { get; set; }
        public int SalesPrice { get; set; }
        public int Stock { get; set; }
        public int IdUser { get; set; }
    }
}

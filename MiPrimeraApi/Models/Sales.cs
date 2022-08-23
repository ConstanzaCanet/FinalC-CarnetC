namespace MiPrimeraApi.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public string coments { get; set; }

        public Sale()
        {
            Id = 0;
            coments = String.Empty;
        }

        public Sale(int id, string coments)
        {
            this.Id = id;
            this.coments = coments;
        }


    }
}

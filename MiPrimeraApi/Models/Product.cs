using System;

namespace MiPrimeraApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        private string description;
        private double cost;
        private double salesPrice;
        private int stock;
        public int IdUser;


        public Product()
        {
            Id = 0;
            description = string.Empty;
            cost = 0;
            salesPrice = 0;
            stock = 0;
            IdUser = 0;
        }


        public Product(int id, string description, int cost, int salesPrice, int stock, string idUser, int IdUser)
        {
            Id = id;
            this.description = description;
            this.cost = cost;
            this.salesPrice = salesPrice;
            this.stock = stock;
            this.IdUser = IdUser;
        }

        //setters & getters

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        public double Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
        public double SalesPrice
        {
            get
            {
                return salesPrice;
            }
            set
            {
                salesPrice = value;
            }
        }
        public int Stock
        {
            get
            {
                return stock;
            }
            set
            {
                stock = value;
            }
        }

    }
}

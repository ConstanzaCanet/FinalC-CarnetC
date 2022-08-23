using MiPrimeraApi.Models;
using System.Data.SqlClient;

namespace MiPrimeraApi.Repository
{
    public static class ProductHandler
    {
        public const string ConnectionString = "Server=DESKTOP-LLLRSER;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Product> GetAllProductos()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Producto", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Product producto = new Product();
                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUser = Convert.ToInt32(dataReader["IdUsuario"]);
                                producto.Cost = Convert.ToInt32(dataReader["Costo"]);
                                producto.SalesPrice = Convert.ToInt32(dataReader["PrecioVenta"]);
                                producto.Description = dataReader["Descripciones"].ToString();

                                products.Add(producto);
                            }
                        }
                    }

                    sqlConnection.Close();
                }

                return products;
            }
        }
    }
}

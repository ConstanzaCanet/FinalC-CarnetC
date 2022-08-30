using MiPrimeraApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraApi.Repository
{
    public static class SoldProductHandler
    {
        public const string ConnectionString = "Server=DESKTOP-LLLRSER;Database=SistemaGestion;Trusted_Connection=True";
        //Traigo productos vendidos, correspondientes al user logueado
        public static List<Product> GetSoldProductsByUser(int idUser)
        {
            List<Product> ventas = new List<Product>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySerch = "SELECT * FROM Producto P INNER JOIN ProductoVendido PV ON P.Id = PV.IdProducto INNER JOIN Venta V ON PV.IdVenta = V.Id WHERE IdUsuario = @idUser;";

                SqlParameter sqlParameter = new SqlParameter("idUser", SqlDbType.BigInt);
                sqlParameter.Value = idUser;


                using (SqlCommand sqlCommand = new SqlCommand(querySerch, sqlConnection))
                {
                    sqlCommand.Parameters.Add(sqlParameter);
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Product product = new Product();
                                product.Description = dataReader["Descripciones"].ToString();
                                product.Id = Convert.ToInt32(dataReader["IdProducto"]);
                                product.Cost = Convert.ToInt32(dataReader["Costo"]);
                                product.Stock = Convert.ToInt32(dataReader["Stock"]);
                                product.IdUser = Convert.ToInt32(dataReader["IdUsuario"]);
                                product.SalesPrice = Convert.ToInt32(dataReader["PrecioVenta"]);

                                ventas.Add(product);
                            }
                        }
                    }

                    sqlConnection.Close();
                }

                return ventas;
            }
        }



    }
}

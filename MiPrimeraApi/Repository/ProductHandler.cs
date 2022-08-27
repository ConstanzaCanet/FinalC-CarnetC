using MiPrimeraApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraApi.Repository
{
    public static class ProductHandler
    {
        public const string ConnectionString = "Server=DESKTOP-LLLRSER;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Product> GetAllProductos(int id)
        {
            List<Product> productos = new List<Product>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlParameter sqlParameter = new SqlParameter("idUsuario", SqlDbType.BigInt);
                sqlParameter.Value = id;

                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Producto WHERE IdUsuario = @idUsuario", sqlConnection))
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
                                Product producto = new Product();
                                producto.Id = Convert.ToInt32(dataReader["Id"]);
                                producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                producto.IdUser = Convert.ToInt32(dataReader["IdUsuario"]);
                                producto.Cost = Convert.ToInt32(dataReader["Costo"]);
                                producto.SalesPrice = Convert.ToInt32(dataReader["PrecioVenta"]);
                                producto.Description = dataReader["Descripciones"].ToString();

                                productos.Add(producto);
                            }
                        }
                    }

                    sqlConnection.Close();
                }

                return productos;
            }
        }




        public static bool CreateNewProduct(Product product)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[Producto] (Descripciones, Costo, PrecioVenta , Stock, IdUsuario) VALUES(@Descripciones, @Costo, @PrecioVenta, @Stock , @IdUsuario);";


                    SqlParameter DescriptionParameter = new SqlParameter("Description", SqlDbType.VarChar) { Value = product.Description };
                    SqlParameter CostParameter = new SqlParameter("Cost", SqlDbType.BigInt) { Value = product.Cost };
                    SqlParameter SalesPriceParameter = new SqlParameter("SalesPrice", SqlDbType.BigInt) { Value = product.SalesPrice };
                    SqlParameter StockParameter = new SqlParameter("Stock", SqlDbType.BigInt) { Value = product.Stock };
                    SqlParameter IdUserParameter = new SqlParameter("IdUser", SqlDbType.BigInt) { Value = product.IdUser };



                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(DescriptionParameter);
                        sqlCommand.Parameters.Add(CostParameter);
                        sqlCommand.Parameters.Add(SalesPriceParameter);
                        sqlCommand.Parameters.Add(StockParameter);
                        sqlCommand.Parameters.Add(IdUserParameter);

                        int numberOfRows = sqlCommand.ExecuteNonQuery();
                        if (numberOfRows > 0)
                        {
                            result = true;
                        }

                    }

                    sqlConnection.Close();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;

        }




        public static bool ChangeProduct(Product producto)
        {
            bool result = false;
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    string queryUpdate = "UPDATE [SistemaGestion].[dbo].[Producto] SET (Descripciones, Costo, PrecioVenta,Stock,IdUsuario) VALUES(@Descripciones, @Costo, @PrecioVenta,@Stock);";

                    SqlParameter descripcionesParameter = new SqlParameter("Descripciones", SqlDbType.BigInt) { Value = producto.Description };
                    SqlParameter costoParameter = new SqlParameter("Costo", SqlDbType.Int) { Value = producto.Cost };
                    SqlParameter precioParameter = new SqlParameter("PrecioVenta", SqlDbType.BigInt) { Value = producto.SalesPrice };
                    SqlParameter stokParameter = new SqlParameter("Stock", SqlDbType.BigInt) { Value = producto.Stock };
  


                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(descripcionesParameter);
                        sqlCommand.Parameters.Add(costoParameter);
                        sqlCommand.Parameters.Add(precioParameter);
                        sqlCommand.Parameters.Add(stokParameter);

                        int numberOfRows = sqlCommand.ExecuteNonQuery();
                        if (numberOfRows > 0)
                        {
                            result = true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return result;
        }










        public static bool DeleteProduct(int id)
        {
            bool result = false;

            try
            {

                using (SqlConnection sqlConnection = new SqlConnection())
                {
                    string queryDelete = "DELETE FROM [SistemaGestion].[dbo].[Producto] WHERE Id = @idProducto";

                    SqlParameter sqlParameter = new SqlParameter("idProducto", SqlDbType.BigInt);
                    sqlParameter.Value = id;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(sqlParameter);

                        int numberOfRows = sqlCommand.ExecuteNonQuery();
                        if (numberOfRows > 0)
                        {
                            result = true;
                        }

                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return result;
        }







    }
}

using MiPrimeraApi.Models;
using System.Data;
using System.Data.SqlClient;

namespace MiPrimeraApi.Repository
{
    public static class SalesHandler
    {
        public const string ConnectionString = "Server=DESKTOP-LLLRSER;Database=SistemaGestion;Trusted_Connection=True";

        public static List<Sale> GetAllSales()
        {
            List<Sale> list = new List<Sale>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();
                    sqlCommand.CommandText = "SELECT * FROM Venta;";

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                    sqlDataAdapter.SelectCommand = sqlCommand;

                    DataTable table = new DataTable();
                    sqlDataAdapter.Fill(table);
                    sqlCommand.Connection.Close();

                    foreach (DataRow row in table.Rows)
                    {
                        Sale sales = new Sale();
                        sales.Id = Convert.ToInt32(row["Id"]);
                        sales.coments = row["Comentarios"].ToString();

                        list.Add(sales);                    
                    }
                sqlCommand.Connection.Close();
                }
            }

        return list;
        }




        //Traigo productos vendidos, correspondientes al user logueado
        public static List<Sale> GetProductosVendidos(int idUser)
        {
            List<Sale> ventas = new List<Sale>();
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
                                Sale venta = new Sale();
                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.coments = dataReader["Comentarios"].ToString();

                                ventas.Add(venta);
                            }
                        }
                    }

                    sqlConnection.Close();
                }

                return ventas;
            }
        }




        //Agrego una funcion que me permita realizar cambios en alguna vente
        public static bool ChangeComent(Sale comentNew)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    string queryPut = "UPDATE [SistemaGestion].[dbo].[Venta] SET Comentarios = @comentNew WHERE Id = @Id;";

                    SqlParameter ComentParameter = new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = comentNew.coments };
                    SqlParameter idParameter = new SqlParameter("Id", SqlDbType.BigInt) { Value = comentNew.Id };

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryPut, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(ComentParameter);
                        sqlCommand.Parameters.Add(idParameter);


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


        //Crear Ventas---> Compra: creo una venta que reciba una lista de productos--->venta + productos vendidos


    }
}

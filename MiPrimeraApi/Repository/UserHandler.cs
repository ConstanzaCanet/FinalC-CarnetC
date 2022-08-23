using MiPrimeraApi.Models;
using System.Data;
using System.Data.SqlClient;


namespace MiPrimeraApi2.Repository
{
    public static class UserHandler
    {
        public const string ConnectionString = "Server=DESKTOP-LLLRSER;Database=SistemaGestion;Trusted_Connection=True";

        public static List<User> GetUsers()
        {
            List<User> resultados = new List<User>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas
                        if(dataReader.HasRows)
                        {
                            while(dataReader.Read())
                            {
                                User usuario = new User();

                                usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                usuario.UserName = dataReader["NombreUsuario"].ToString();
                                usuario.Name = dataReader["Nombre"].ToString();
                                usuario.Lastname = dataReader["Apellido"].ToString();
                                usuario.Password = dataReader["Contraseña"].ToString();
                                usuario.Email = dataReader["Mail"].ToString();

                                resultados.Add(usuario);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return resultados;
        }


        public static List<User> GetUser(int id)
        {
            List<User> users = new List<User>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    SqlParameter sqlParameterUserName = new SqlParameter("Id", SqlDbType.BigInt);
                    sqlParameterUserName.Value = id;

                    using (SqlCommand sqlCommand = new SqlCommand(
                       "SELECT * FROM Usuario WHERE Id =  @Id;", sqlConnection))
                    {
                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {

                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    User user = new User();
                                    user.Id = Convert.ToInt32(dataReader["Id"]);
                                    user.UserName = dataReader["NombreUsuario"].ToString();
                                    user.Name = dataReader["Nombre"].ToString();
                                    user.Lastname = dataReader["Apellido"].ToString();
                                    user.Email = dataReader["Mail"].ToString();


                                }
                            }
                        }
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return users;

        }


        public static bool CreateNewUser(User user)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    string queryAdd = "INSERT INTO [SistemaGestion].[dbo].[Usuario] (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES(@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail);";


                    SqlParameter NombreParameter = new SqlParameter("Nombre", SqlDbType.VarChar) { Value = user.Name };
                    SqlParameter ApellidoParameter = new SqlParameter("Apellido", SqlDbType.VarChar) { Value = user.Lastname };
                    SqlParameter NombreUsuarioParameter = new SqlParameter("NombreUsuario", SqlDbType.VarChar) { Value = user.UserName };
                    SqlParameter PasswordParameter = new SqlParameter("Contraseña", SqlDbType.VarChar) { Value = user.Password };
                    SqlParameter MailParameter = new SqlParameter("Mail", SqlDbType.VarChar) { Value = user.Email };



                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryAdd, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(NombreParameter);
                        sqlCommand.Parameters.Add(ApellidoParameter);
                        sqlCommand.Parameters.Add(NombreUsuarioParameter);
                        sqlCommand.Parameters.Add(PasswordParameter);
                        sqlCommand.Parameters.Add(MailParameter);

                        int numberOfRows = sqlCommand.ExecuteNonQuery();
                        if(numberOfRows > 0)
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


        public static bool ChangeNameUser(User user)
        {
            bool result = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {

                    string queryPut = "UPDATE [SistemaGestion].[dbo].[Usuario] SET Nombre = @nombre WHERE Id = @id;";


                    SqlParameter nombreParameter = new SqlParameter("Nombre", SqlDbType.VarChar) { Value = user.Name };
                    SqlParameter idParameter = new SqlParameter("id", SqlDbType.BigInt) { Value = user.Id };
         

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryPut, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(nombreParameter);
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


























        public static bool DeleteUser(int id)
        {
            bool result = false;
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE * FROM Usuario WHERE Id = @id";
                    SqlParameter sqlParameter = new SqlParameter("id",System.Data.SqlDbType.BigInt);
                
                    sqlConnection.Open();
                
                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete , sqlConnection))
                    {

                        sqlCommand.Parameters.Add(sqlParameter);
                        int numberOfRows = sqlCommand.ExecuteNonQuery();
                        if(numberOfRows > 0)
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



    }

}
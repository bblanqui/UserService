using Datos;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace UserService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UserConsumer" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UserConsumer.svc o UserConsumer.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UserConsumer : IUserConsumer
    {
        private readonly  ConectionUser _databaseConnection;

        public UserConsumer()
        {
            _databaseConnection = new ConectionUser(); // Inicialización del objeto aquí
        }
        public bool CreateUser(string name, string gender, DateTime birthdate)
        {
            using (var connection = _databaseConnection.ConectUser())
            {

                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_crud_user";
                    command.Parameters.AddWithValue("@operation", "C");
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@birthdate", birthdate);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
        }

        public bool DeleteUser(int id)
        {
            using (var connection = _databaseConnection.ConectUser())
            {

                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_crud_user";
                    command.Parameters.AddWithValue("@operation", "D");
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
        }

        public List<User> ReadUsers()
        {
            List<User> userList = new List<User>();
            using (var connection = _databaseConnection.ConectUser())
            {
               
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_crud_user";
                    command.Parameters.AddWithValue("@operation", "R");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                IdUser = Convert.ToInt32(reader["user_id"]),
                                NameUser = reader["name"].ToString(),
                                Birthdate = reader["birthdate"].ToString(),
                                GenderUser = reader["gender"].ToString()
                            };
                            userList.Add(user);
                        }
                    }

                }
            }
            return userList;

        }

        public List<User> SearchUser(string name)
        {
            List<User> userList = new List<User>();
            using (var connection = _databaseConnection.ConectUser())
            {

                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_crud_user";
                    command.Parameters.AddWithValue("@operation", "S");
                    command.Parameters.AddWithValue("@name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                IdUser = Convert.ToInt32(reader["user_id"]),
                                NameUser = reader["name"].ToString(),
                                Birthdate = reader["birthdate"].ToString(),
                                GenderUser = reader["gender"].ToString()
                            };
                            userList.Add(user);
                        }
                    }

                }
            }
            return userList;
        }

        public bool UpdateUser(string name, string gender, DateTime birthdate, int id)
        {
            using (var connection = _databaseConnection.ConectUser())
            {

                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_crud_user";
                    command.Parameters.AddWithValue("@operation", "U");
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@birthdate", birthdate);
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
          
        }

     
    }

  
}


using Datos; // Referencia a proyecto de capa de datos
using Model; // Referencia a proyecto de modelo
using System;
using System.Collections.Generic;
using System.Data;// Para tipos como Command, DataReader



namespace UserService
{

    public class UserConsumer : IUserConsumer // Implementa interfaz IUserConsumer
    {
        private readonly  ConectionUser _databaseConnection;// inyectando conexion

        public UserConsumer()
        {
            _databaseConnection = new ConectionUser(); // Inicializa conexión
        }
        public bool CreateUser(User usuario)//crea usuario, resibe un objeto tipo User y devuelve un boolean
        {
            using (var connection = _databaseConnection.ConectUser())
            {

                connection.Open();

                using (var command = connection.CreateCommand())
                {   
                    // Configura parámetros y ejecuta SP
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_crud_user";
                    command.Parameters.AddWithValue("@operation", "C");
                    command.Parameters.AddWithValue("@name", usuario.NameUser);
                    command.Parameters.AddWithValue("@gender", usuario.GenderUser);
                    command.Parameters.AddWithValue("@birthdate", usuario.Birthdate);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
        }

        public bool DeleteUser(int id)//elimina user resibe el id del usuario retorna un boolean
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

        public List<User> ReadUsers()// devuelve un a lista de usuario timpo Model.User
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
                                Birthdate = Convert.ToDateTime(reader["birthdate"]),
                                GenderUser = reader["gender"].ToString()
                            };
                            userList.Add(user);
                        }
                    }

                }
            }
            return userList;

        }

        public List<User> SearchUser(string name) //resibe un string como parametro devuleve una lista de usuario tipo Model.User
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
                                Birthdate = Convert.ToDateTime(reader["birthdate"]),
                                GenderUser = reader["gender"].ToString()
                            };
                            userList.Add(user);
                        }
                    }

                }
            }
            return userList;
        }

        public bool UpdateUser(User usuario)// actualiza un usuario, resibe como parametro un objeto tipo usaurio
        {
            using (var connection = _databaseConnection.ConectUser())
            {

                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_crud_user";
                    command.Parameters.AddWithValue("@operation", "U");
                    command.Parameters.AddWithValue("@name", usuario.NameUser);
                    command.Parameters.AddWithValue("@gender", usuario.GenderUser);
                    command.Parameters.AddWithValue("@birthdate", usuario.Birthdate);
                    command.Parameters.AddWithValue("@id", usuario.IdUser);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
          
        }

       public List<User> SearchUserId(int id) // resibe un id devuelve una lista de usuarios
        {
            List<User> userList = new List<User>();
            using (var connection = _databaseConnection.ConectUser())
            {

                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "sp_crud_user";
                    command.Parameters.AddWithValue("@operation", "SID");
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                IdUser = Convert.ToInt32(reader["user_id"]),
                                NameUser = reader["name"].ToString(),
                                Birthdate = Convert.ToDateTime(reader["birthdate"]),
                                GenderUser = reader["gender"].ToString()
                            };
                            userList.Add(user);
                        }
                    }

                }
            }
            return userList;
        }

      
    }

  
}


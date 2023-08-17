using ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UserService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUserConsumer" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUserConsumer
    {
        [OperationContract]
        bool UpdateUser(string name, string gender, DateTime birthdate, int id);

        [OperationContract]
        bool CreateUser(string name, string gender, DateTime birthdate);

        [OperationContract]
        List<User> SearchUser(string name);

        [OperationContract]
        List<User> ReadUsers();

        [OperationContract]
        bool DeleteUser(int id);
    }
}


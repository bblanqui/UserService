using Model;// usamos el modelo
using System;
using System.Collections.Generic;
using System.ServiceModel;// Para servicios WCF


namespace UserService
{
    [ServiceContract] // contrato de servicio WCF
    public interface IUserConsumer
    {
        [OperationContract] //operación del servicio
        bool UpdateUser(User usuario); // Actualiza usuario

        [OperationContract]
        bool CreateUser(User usuario);// Crea usuario

        [OperationContract]
        List<User> SearchUser(string name);// Busca por nombre

        [OperationContract]
        List<User> ReadUsers(); // Obtiene todos los usuarios

        [OperationContract]
        bool DeleteUser(int id);// Elimina por id

        [OperationContract]
        List<User> SearchUserId(int id); // Busca por id
    }
}


﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BancoCK
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IConsumoBaseDatos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IConsumoBaseDatos
    {

        [OperationContract]
        void abrirConexion();

        [OperationContract]
        void cerrarConexion();

        [OperationContract]
        string mostrarDescripcion(string tipoPrestamo);

        [OperationContract]
        string mostrarRequisitos(string tipoPrestamo);

        [OperationContract]
        void guardarInformacionClienteNoAutenticado(string cedula, string nombre, string apellido1, string apellido2, string correo, int telefono, float salarioNeto, int añosLaborando, float salarioBruto, string rol);

        [OperationContract]
        void registrarPrestamoCliente(string identificacion,string fecha);
    }
}

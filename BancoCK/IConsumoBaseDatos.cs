using System;
using System.Collections.Generic;
using System.Data;
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
        void guardarInformacionClienteNoAutenticado(string cedula, string nombre, string apellido1, string apellido2, string correo, int telefono,string rol);

        [OperationContract]
        void registrarPrestamoCliente(string identificacion, string fechaCredito, string estadoCredito, float monto, int plazoAños, float cuotaMensual, float salarioNeto, int añosLaborando, float salarioBruto);

        [OperationContract]

        string CredencialesUsuario( string Identificacion, string password);

        [OperationContract]
        void RegistrarUsuario( string Identificacion, string Nombre, string Rol,string PrimerApellido, string SegundoApellido, string Correo, string Telefono, string SalarioNeto, string AñosLaborando, string SalarioBruto, string Password, string TipoCedula );

        [OperationContract]
        DataTable devolverPrestamosClientes();

        [OperationContract]
        string devolverCedulaAnalista(string nombre, string apellido1, string apellido2);

        [OperationContract]
        void asignarAnalista(string identificacion,int idPrestamo);

        [OperationContract]
        DataTable devolverPrestamos_nombre_cedula(string tipoPrestamo, string cedula);

        [OperationContract]
        DataTable devolverPrestamos_tipoPrestamo(string tipoPrestamo);

        [OperationContract]
        void cambiarEstadoPrestamoSolicitud(int idPrestamo);

        [OperationContract]
        float devolverTasaTipoPrestamo(string tipoPrestamo);

        [OperationContract]
        string devolverLimiteMontoPrestamo(string tipoPrestamo);

        [OperationContract]
        string devolverLimiteMontoPrestamoDolares(string tipoPrestamo);

        [OperationContract]
        float devolverTasaTipoPrestamoDolares(string tipoPrestamo);

        [OperationContract]
        double calcularCuotaMensual(float prestamo, int años, float tasaInteres);

    }
}

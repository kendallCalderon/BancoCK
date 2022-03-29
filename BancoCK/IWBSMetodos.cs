using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BancoCK
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWBSmetodos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWBSmetodos
    {
        [OperationContract]
        void abrirConexion();

        [OperationContract]
        void cerrarConexion();


        [OperationContract]
        DataTable devolverPrestamosClientes();

        [OperationContract]
        void guardarInformacionClienteNoAutenticado(string cedula, string nombre, string apellido1, string apellido2, string correo, int telefono, string rol);

        [OperationContract]
        string mostrarDescripcion(string tipoPrestamo);


        [OperationContract]
        string mostrarRequisitos(string tipoPrestamo);


        [OperationContract]
        void registrarPrestamoClienteOriginal(string identificacion, string fechaCredito, string estadoCredito, float monto, int plazoAños, double cuotaMensual, float salarioNeto, int añosLaborando, float salarioBruto, string tipoPrestamo);




        [OperationContract]
        string CredencialesUsuario(string Identificacion, string password);


        [OperationContract]
        void RegistrarUsuario(string Identificacion, string Nombre, string Rol, string PrimerApellido, string SegundoApellido, string Correo, string Telefono, string Password, string TipoCedula);


        [OperationContract]
        void asignarAnalista(string identificacion, int idPrestamo);


        [OperationContract]
        DataTable devolverPrestamos_nombre_cedula(string tipoPrestamo, string cedula);


        [OperationContract]
        DataTable devolverPrestamos_tipoPrestamo(string tipoPrestamo);


        [OperationContract]
        void cambiarEstadoPrestamoSolicitud(int idPrestamo);


        [OperationContract]
        string devolverCedulaAnalista(string nombre, string apellido1, string apellido2);


        [OperationContract]
        bool ValidarExistenciaUsuario(string Identificacion);



        [OperationContract]
        float devolverTasaTipoPrestamo(string tipoPrestamo);




        [OperationContract]
        bool enviarCorreo(string receptor);


        [OperationContract]
        bool enviarCorreoNoLogueado(string receptor);


        [OperationContract]
        string ObtenerCorreo(string Identificacion, string Rol);

        [OperationContract]
        string devolverLimiteMontoPrestamo(string tipoPrestamo);


        [OperationContract]
        string devolverLimiteMontoPrestamoDolares(string tipoPrestamo);


        [OperationContract]
        float devolverTasaTipoPrestamoDolares(string tipoPrestamo);

        [OperationContract]

        double calcularCuotaMensual(float prestamo, int años, float tasaInteres);



        [OperationContract]
        float devolverTasaDolaresUsuarioNoLogeado(string tipoPrestamo);


        [OperationContract]
        float devolverTasaColonesUsuarioNoLogeado(string tipoPrestamo);


        [OperationContract]
        void registrarIndicadorPrestamoClickUsuarioNoAutenticado(string tipoPrestamo, int contador, string tipoIndicador, string fecha);

    }
}

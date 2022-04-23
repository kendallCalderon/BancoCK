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
        void registrarPrestamoClienteOriginal(string identificacion, DateTime fechaCredito, string estadoCredito, float monto, int plazoAños, double cuotaMensual, float salarioNeto, int añosLaborando, float salarioBruto, string tipoPrestamo,int idMoneda);

        [OperationContract]
        void guardarInformacionClienteNoAutenticado(string cedula, string nombre, string apellido1, string apellido2, string correo, int telefono, string rol);

        [OperationContract]
        void registrarPrestamoCliente(string identificacion, DateTime fechaCredito, string estadoCredito, float monto, int plazoAños, double cuotaMensual, float salarioNeto, int añosLaborando, float salarioBruto, string tipoPrestamo, int idMoneda);

        [OperationContract]

        string CredencialesUsuario(string Identificacion, string password);

        [OperationContract]
        void RegistrarUsuario(string Identificacion, string Nombre, string Rol, string PrimerApellido, string SegundoApellido, string Correo, string Telefono, string Password, string TipoCedula);

        [OperationContract]
        DataTable devolverPrestamosClientes();

        [OperationContract]
        string devolverCedulaAnalista(string nombre, string apellido1, string apellido2);

        [OperationContract]
        void asignarAnalista(string identificacion, int idPrestamo);

        [OperationContract]
        DataTable devolverPrestamos_nombre_cedula(string tipoPrestamo, string cedula);

        [OperationContract]
        DataTable devolverPrestamos_tipoPrestamo(string tipoPrestamo);

        [OperationContract]
        void cambiarEstadoPrestamoSolicitud(int idPrestamo);

        [OperationContract]
        float devolverTasaTipoPrestamo(string tipoPrestamo);

        [OperationContract]
        bool ValidarExistenciaUsuario(string Identificacion);

        [OperationContract]
        bool enviarCorreo(string receptor);

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
        void registrarIndicadorPrestamoClickUsuarioNoAutenticado(string tipoPrestamo, int contador, string tipoIndicador, DateTime fecha);
        [OperationContract]
        void registrarIndicadorPrestamoUsuarioNoAutenticadoPrecalculo(string tipoPrestamo, int contador, string tipoIndicador, DateTime fecha);
        [OperationContract]
        void registrarIndicadorPrestamoUsuarioAutenticadoPrecalculo(string tipoPrestamo, int contador, string tipoIndicador, DateTime fecha);
        [OperationContract]
        DataTable devolverInformacionPrestamos(string tipoPrestamo);
        [OperationContract]
        void registrarIndicadorPrestamoClickAutenticado(string tipoPrestamo, int contador, string tipoIndicador, DateTime fecha);
        [OperationContract]
        DataTable devolverFechasIndicadores();
        [OperationContract]
        int indicadorAutenticadoVivienda(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int indicadorAutenticadoPersonal(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int indicadorAutenticadoApoyoNegocio(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int indicadorAutenticadoEducacion(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int indicadorAutenticadoDeudas(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int indicadorAutenticadoVehiculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int indicadorNoAutenticadoVehiculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresNoAutenticadosDeudas(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresNoAutenticadosEducacion(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresNoAutenticadosApoyoNegocio(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresNoAutenticadosPersonal(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresNoAutenticadosVivienda(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresNoAutenticadosPersonalPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresNoAutenticadosApoyoNegocioPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresNoAutenticadoViviendaPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresNoAutenticadoEducacionPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresNoAutenticadoDeudasPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]

        int devolverIndicadoresNoAutenticadoVehiculoPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresAutenticadoVehiculoPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresAutenticadoDeudasPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresAutenticadoEducacionPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresAutenticadoViviendaPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresAutenticadoApoyoNegocioPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        int devolverIndicadoresAutenticadoPersonalPrecalculo(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        string generalDeudas();
        [OperationContract]
        string generalApoyoNegocio();
        [OperationContract]
        string generalEducacion();
        [OperationContract]
        string generalPersonal();
        [OperationContract]
        string generalPrestamoVivienda();
        [OperationContract]
        string generalVehiculo();

        [OperationContract]
        string generalDeudasPrecalculo();
        [OperationContract]
        string generalApoyoNegocioPrecalculo();
        [OperationContract]
        string generalEducacionPrecalculo();
        [OperationContract]
        string generalPersonalPrecalculo();
        [OperationContract]
        string generalPrestamoViviendaPrecalculo();
        [OperationContract]
        string generalVehiculoPrecalculo();
        [OperationContract]
        List<string>comboAnalistas();
        [OperationContract]
        DataTable traerPrestamosEntreFechas(DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        bool traerAnalistasGenerales(string cedula);
        [OperationContract]
        string EncargoAnalista(string cedula);
        [OperationContract]
        void correoAnalistaInforme(string correo);
        [OperationContract]
        int ContadorAnalista(string cedula);
        [OperationContract]
        void sumarAnalista(int numero);
        [OperationContract]
        DataTable traePrestamoxNombreCompleto(string nombre, string apellido1, string apellido2, string estadoCredito,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxNombreconApellido(string nombre, string apellido1, string estadoCredito, string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxNombre(string nombre, string estadoCredito,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxApellidos(string apellido1, string apellido2, string estadoCredito,string tipoPrestamos);
        [OperationContract]
        DataTable traePrestamoxApellido(string apellido1, string estadoCredito,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxCorreo(string correo, string estadoCredito,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxTelefono(int telefono, string estadoCredito,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxIdentificacion(string identificacion, string estadoCredito,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxTipoEstado(string tipoPrestamo, string estadoCredito);
        [OperationContract]
        DataTable traePrestamoxfechasEstado(DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo,string estadoCredito);
        [OperationContract]
        DataTable traePrestamoxNombreCompletoFechas(string nombre, string apellido1, string apellido2, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxNombreconApellidoFechas(string nombre, string apellido1, DateTime fechaInicio, DateTime fechaFinal, string estadoCredito, string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxNombreFechas(string nombre, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxApellidosFechas(string apellido1, string apellido2, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxApellidoFechas(string apellido1,string estadoCredito,DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxCorreoFechas(string cadena, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxTelefonoFechas(int telefono, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxIdentificacionFechas(string identificacion,string estadoCredito, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo);
        [OperationContract]
        DataTable traePrestamoxTipoEstadoFechas(string tipoPrestamo, string estadoCredito, DateTime fechaInicio, DateTime fechaFinal);
        [OperationContract]
        DataTable traePrestamoxTipoEstadoAnalista(string tipoPrestamo, string Identificacion);
        [OperationContract]
        DataTable traePrestamoxTipoEstadoFechasAnalista(string tipoPrestamo, DateTime fechaInicio, DateTime fechaFinal, string Identificacion);
        [OperationContract]
        DataTable traePrestamoxNombreCompletoFechasAnalista(string nombre,string apellido1, string apellido2,string tipoPrestamo, DateTime fechaInicio, DateTime fechaFinal, string Identificacion);
        [OperationContract]
        DataTable traePrestamoxNombreconApellidoFechasAnalista(string nombre, string apellido1, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo, string Identificacion);
        [OperationContract]
        DataTable traePrestamoxNombreFechasAnalista(string nombre,DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo, string Identificacion);
        [OperationContract]
        DataTable traePrestamoxApellidosFechasAnalistas(string apellido1,string apellido2, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo, string Identificacion);

        [OperationContract]
        DataTable ObtenerAnalistas();

        [OperationContract]
        void InsertarAnalista( string Identificacion, string Nombre, string Rol, string Apellido1, string Apellido2, string Correo, string Telefono, string Contraseña);

        [OperationContract]
        void ModificarAnalista(string Identificacion, string Nombre, string Apellido1, string Apellido2, string Correo, string Telefono);

        [OperationContract]
        void EliminarAnalista(string Identificacion);
        [OperationContract]
        DataTable traePrestamoxApellidoFechasAnalistas(string apellido1, DateTime fechaInicio, DateTime fechaFinal, string tipoPrestamo, string Identificacion);

        [OperationContract]
        DataTable traePrestamoxCorreoFechasAnalistas(string correo, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo, string Identificacion);

        [OperationContract]
        DataTable traePrestamoxTelefonoFechasAnalista(int telefono, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo, string Identificacion);

        [OperationContract]
        DataTable traePrestamoxIdentificacionFechasAnalista(string Identificacion, DateTime fechaInicio, DateTime fechaFinal,string tipoPrestamo, string IdentificacionFuncionario);

        [OperationContract]
        DataTable traePrestamoxNombreCompletoAnalista(string nombre, string apellido1,string apellido2,string tipoPrestamo, string Identificacion);

        [OperationContract]
        DataTable traePrestamoxNombreconApellidoAnalista(string nombre,string apellido1,string tipoPrestamo, string Identificacion );

        [OperationContract]
        DataTable traePrestamoxNombreAnalista(string nombre,string tipoPrestamo, string Identificacion);

        [OperationContract]
        DataTable traePrestamoxApellidosAnalista(string apellido1,string apellido2,string tipoPrestamo, string Identificacion);

        [OperationContract]
        DataTable traePrestamoxApellidoAnalista(string apellido1,string tipoPrestamo, string Identificacion);

        [OperationContract]
        DataTable traePrestamoxCorreoAnalista(string correo, string tipoPrestamo, string Identificacion);

        [OperationContract]
        DataTable traePrestamoxTelefonoAnalista(int telefono, string tipoPrestamo, string Identificacion);


        [OperationContract]
        DataTable traePrestamoxIdentificacionAnalista(string identificacion,string tipoPrestamo, string IdentificacionFuncionario);

        [OperationContract]
        float traerSalarioBrutoCliente(int idPrestamos);
        [OperationContract]
        void cambiarEstadoParaAprobrarAnalista(int idPrestamo);
        [OperationContract]
        string ObtenerCorreoSolicitudCliente(int idPrestamo);
        [OperationContract]
        void cambiarEstadoParaRechazarAnalista(int idPrestamo);

        [OperationContract]
        DataTable traerRoles();

        [OperationContract]
        DataTable informacionRolxNombreCompleto(string nombre, string apellido1, string apellido2,string rol);

        [OperationContract]
        DataTable informacionRolxNombreApellido(string nombre, string apellido1,string rol);

        [OperationContract]
        DataTable informacionRolxNombre(string nombre,string rol);

        [OperationContract]
        DataTable informacionRolxApellidos(string apellido1,string apellido2,string rol);

        [OperationContract]
        DataTable informacionRolxApellido(string apellido1,string rol);

        [OperationContract]
        DataTable informacionRolxCorreo(string correo,string rol);

        [OperationContract]
        DataTable informacionRolxTelefono(int telefono,string rol);

        [OperationContract]
        DataTable informacionRolxIdentificacion(string identificacion,string rol);

        [OperationContract]
        string traerRolUsuario(string identificacion);

        [OperationContract]
        DataTable traerRolesxrol(string rol);

        [OperationContract]
        List<string> traerAnalistas(string cedula);

        [OperationContract]
        void asignarPrestamos(string cedulaCambio, string cedula);

        [OperationContract]
        void cambioRol(string identificacion, string rol);

        [OperationContract]
        void cambioRolTramitador(string identificacion,string rol,string prestamoEncargo);

        [OperationContract]
        DataTable traerTasas();

        [OperationContract]
        string traerPrestamosxTasas(string prestamo);

        [OperationContract]
        void cambioTasas(float tasaColones, float tasaDolares,string nombrePrestamo);
        [OperationContract]
        void InsertarTramitador(string Identificacion, string Nombre, string Rol, string Apellido1, string Apellido2, string Correo, string Telefono, string Contraseña);

        [OperationContract]
        void ModificarTramitador(string Identificacion, string Nombre, string Apellido1, string Apellido2, string Correo, string Telefono);

        [OperationContract]
        void EliminarTramitador(string Identificacion);

        [OperationContract]
        DataTable ObtenerTramitadores();
    }
}

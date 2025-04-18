﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Banca_En_Linea.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class Easy_Pay_Entities : DbContext
    {
        public Easy_Pay_Entities()
            : base("name=Easy_Pay_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int InsertarCliente(Nullable<long> cedula, string nombre, string apellido, string nombreUsuario, string contrasena, Nullable<System.DateTime> fechaNacimiento, string direccion, string telefono, string correo, byte[] foto, Nullable<System.DateTime> fechaCreacion, Nullable<System.DateTime> fechaModificacion, Nullable<System.DateTime> fechaUltimoIngreso, Nullable<int> pregunta, string respuesta)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("Apellido", apellido) :
                new ObjectParameter("Apellido", typeof(string));
    
            var nombreUsuarioParameter = nombreUsuario != null ?
                new ObjectParameter("NombreUsuario", nombreUsuario) :
                new ObjectParameter("NombreUsuario", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento.HasValue ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(System.DateTime));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var fotoParameter = foto != null ?
                new ObjectParameter("Foto", foto) :
                new ObjectParameter("Foto", typeof(byte[]));
    
            var fechaCreacionParameter = fechaCreacion.HasValue ?
                new ObjectParameter("FechaCreacion", fechaCreacion) :
                new ObjectParameter("FechaCreacion", typeof(System.DateTime));
    
            var fechaModificacionParameter = fechaModificacion.HasValue ?
                new ObjectParameter("FechaModificacion", fechaModificacion) :
                new ObjectParameter("FechaModificacion", typeof(System.DateTime));
    
            var fechaUltimoIngresoParameter = fechaUltimoIngreso.HasValue ?
                new ObjectParameter("FechaUltimoIngreso", fechaUltimoIngreso) :
                new ObjectParameter("FechaUltimoIngreso", typeof(System.DateTime));
    
            var preguntaParameter = pregunta.HasValue ?
                new ObjectParameter("Pregunta", pregunta) :
                new ObjectParameter("Pregunta", typeof(int));
    
            var respuestaParameter = respuesta != null ?
                new ObjectParameter("Respuesta", respuesta) :
                new ObjectParameter("Respuesta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertarCliente", cedulaParameter, nombreParameter, apellidoParameter, nombreUsuarioParameter, contrasenaParameter, fechaNacimientoParameter, direccionParameter, telefonoParameter, correoParameter, fotoParameter, fechaCreacionParameter, fechaModificacionParameter, fechaUltimoIngresoParameter, preguntaParameter, respuestaParameter);
        }
    
        public virtual int sp_CreateTarjetas(Nullable<int> iD, string numeroTarjeta, Nullable<System.DateTime> fechaVencimiento, Nullable<System.DateTime> fechaCreacion, Nullable<int> cVV, Nullable<long> cedula)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var numeroTarjetaParameter = numeroTarjeta != null ?
                new ObjectParameter("NumeroTarjeta", numeroTarjeta) :
                new ObjectParameter("NumeroTarjeta", typeof(string));
    
            var fechaVencimientoParameter = fechaVencimiento.HasValue ?
                new ObjectParameter("FechaVencimiento", fechaVencimiento) :
                new ObjectParameter("FechaVencimiento", typeof(System.DateTime));
    
            var fechaCreacionParameter = fechaCreacion.HasValue ?
                new ObjectParameter("FechaCreacion", fechaCreacion) :
                new ObjectParameter("FechaCreacion", typeof(System.DateTime));
    
            var cVVParameter = cVV.HasValue ?
                new ObjectParameter("CVV", cVV) :
                new ObjectParameter("CVV", typeof(int));
    
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateTarjetas", iDParameter, numeroTarjetaParameter, fechaVencimientoParameter, fechaCreacionParameter, cVVParameter, cedulaParameter);
        }
    
        public virtual ObjectResult<ObtenerInformacionClientePorCorreo_Result> ObtenerInformacionClientePorCorreo(string correo, string contrasena)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ObtenerInformacionClientePorCorreo_Result>("ObtenerInformacionClientePorCorreo", correoParameter, contrasenaParameter);
        }
    
        public virtual int sp_VerificarUsuario(string correo, string contrasena, ObjectParameter usuarioExiste)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_VerificarUsuario", correoParameter, contrasenaParameter, usuarioExiste);
        }
    
        public virtual ObjectResult<sp_ObtenerClientePorCedula_Result> sp_ObtenerClientePorCedula(string correo)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ObtenerClientePorCedula_Result>("sp_ObtenerClientePorCedula", correoParameter);
        }
    
        public virtual ObjectResult<sp_CuentasClientePorCedula_Result> sp_CuentasClientePorCedula(Nullable<long> cedula)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_CuentasClientePorCedula_Result>("sp_CuentasClientePorCedula", cedulaParameter);
        }
    
        public virtual ObjectResult<sp_MovimientosPorCedula_Result> sp_MovimientosPorCedula(Nullable<long> cedula)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_MovimientosPorCedula_Result>("sp_MovimientosPorCedula", cedulaParameter);
        }
    
        public virtual ObjectResult<sp_TarjtasClientePorCedula_Result> sp_TarjtasClientePorCedula(Nullable<long> cedula)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_TarjtasClientePorCedula_Result>("sp_TarjtasClientePorCedula", cedulaParameter);
        }
    
        public virtual ObjectResult<sp_TicketsPorCedula_Result> sp_TicketsPorCedula(Nullable<long> cedula)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_TicketsPorCedula_Result>("sp_TicketsPorCedula", cedulaParameter);
        }
    
        public virtual int sp_ActualizarCliente(Nullable<long> cedula, string correo, string nombreUsuario, string direccion, string telefono, ObjectParameter resultado)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var nombreUsuarioParameter = nombreUsuario != null ?
                new ObjectParameter("NombreUsuario", nombreUsuario) :
                new ObjectParameter("NombreUsuario", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ActualizarCliente", cedulaParameter, correoParameter, nombreUsuarioParameter, direccionParameter, telefonoParameter, resultado);
        }
    
        public virtual int sp_ConsultarContrasena(Nullable<long> cedula, string contrasenaIngresada, ObjectParameter resultado)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            var contrasenaIngresadaParameter = contrasenaIngresada != null ?
                new ObjectParameter("ContrasenaIngresada", contrasenaIngresada) :
                new ObjectParameter("ContrasenaIngresada", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ConsultarContrasena", cedulaParameter, contrasenaIngresadaParameter, resultado);
        }
    
        public virtual int sp_CambiarContrasena(Nullable<long> cedula, string nuevaContrasena, ObjectParameter resultado)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            var nuevaContrasenaParameter = nuevaContrasena != null ?
                new ObjectParameter("NuevaContrasena", nuevaContrasena) :
                new ObjectParameter("NuevaContrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CambiarContrasena", cedulaParameter, nuevaContrasenaParameter, resultado);
        }
    
        public virtual int sp_CrearCuenta(Nullable<long> cedula, ObjectParameter resultado)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CrearCuenta", cedulaParameter, resultado);
        }
    
        public virtual int sp_VerificarTelefono(string telefono, ObjectParameter cedula, ObjectParameter nombre, ObjectParameter apellido, ObjectParameter resultado)
        {
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_VerificarTelefono", telefonoParameter, cedula, nombre, apellido, resultado);
        }
    
        public virtual int sp_TransferirSaldo(Nullable<long> cedulaRemitente, Nullable<long> cedulaReceptor, Nullable<decimal> monto, ObjectParameter resultado)
        {
            var cedulaRemitenteParameter = cedulaRemitente.HasValue ?
                new ObjectParameter("CedulaRemitente", cedulaRemitente) :
                new ObjectParameter("CedulaRemitente", typeof(long));
    
            var cedulaReceptorParameter = cedulaReceptor.HasValue ?
                new ObjectParameter("CedulaReceptor", cedulaReceptor) :
                new ObjectParameter("CedulaReceptor", typeof(long));
    
            var montoParameter = monto.HasValue ?
                new ObjectParameter("Monto", monto) :
                new ObjectParameter("Monto", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_TransferirSaldo", cedulaRemitenteParameter, cedulaReceptorParameter, montoParameter, resultado);
        }
    
        public virtual int sp_ObtenerSaldo(Nullable<long> cedula, ObjectParameter saldo, ObjectParameter resultado)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ObtenerSaldo", cedulaParameter, saldo, resultado);
        }
    }
}

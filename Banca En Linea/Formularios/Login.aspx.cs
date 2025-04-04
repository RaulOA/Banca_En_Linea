using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Banca_En_Linea.Data;
using Microsoft.Ajax.Utilities;

//Llama a el ModeloCliente

namespace Banca_En_Linea
{
    public partial class _Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string usuario = txtEmail.Text;
            string contrasena = txtContrasena.Text;
            // habilitar la visualizacion del mensaje de error en caso de que exista uno y mostrar el mensaje, o caso contrario insertar el cliente
            string error = ValidarFormulario(usuario, contrasena);
            if (error != null)
            {
                LblError.Text = error;
                LblError.Visible = true;
                return;
            }
            else
            {
                LblError.Visible = false;

                // verificar usuario y contraseña mediante el sp_VerificarUsuario
                using (Easy_Pay_Entities entities = new Easy_Pay_Entities())
                {
                    ObjectParameter usuarioExiste = new ObjectParameter("UsuarioExiste", typeof(bool));
                    entities.sp_VerificarUsuario(usuario, contrasena, usuarioExiste);

                    if (!(bool)usuarioExiste.Value)
                    {
                        LblError.Text = "Usuario o contraseña incorrectos";
                        LblError.Visible = true;
                        return;
                    }
                    else
                    {
                        // Obtener los datos del usuario
                        var cliente = entities.sp_ObtenerClientePorCedula(usuario).FirstOrDefault();
                       

                        if (cliente != null)
                        {
                            // Guardar los datos del usuario en la variable de sesión
                            var tarjetas = entities.sp_TarjtasClientePorCedula(cliente.Cedula).FirstOrDefault();
                            var Cuentas = entities.sp_CuentasClientePorCedula(cliente.Cedula).FirstOrDefault();
                            var Tikets = entities.sp_TicketsPorCedula(cliente.Cedula).FirstOrDefault();
                            var Movimientos = entities.sp_MovimientosPorCedula(cliente.Cedula).FirstOrDefault();

                            Session["DatosCliente"] = new DatosCliente
                            {
                                Cedula = cliente.Cedula,
                                Nombre  = cliente.Nombre,
                                Apellido = cliente.Apellido,
                                NombreUsuario = cliente.NombreUsuario,
                                Correo = cliente.Correo,
                                FechaNacimiento = cliente.FechaNacimiento.HasValue ? cliente.FechaNacimiento.Value : DateTime.MinValue,
                                Direccion = cliente.Direccion,
                                Telefono = cliente.Telefono,
                                NumeroTarjeta = tarjetas.NumeroTarjeta,
                                tarjetaCVV = tarjetas.CVV,
                                FechaVencimientoTarjeta= tarjetas.FechaVencimiento,
                                cuentaSaldo = Cuentas.Saldo,
                                TipoCuenta = Cuentas.TipoCuenta,
                                NumeroDeCuenta = Cuentas.NumeroDeCuenta,
                                MonedaID = Cuentas.MonedaID,
                                MovimientosMonto = Movimientos.Monto,
                                FechaMovimiento =  Movimientos.FechaMovimiento,
                                CatalogoMovimientoID = Movimientos.CatalogoMovimientosID,
                                CuantaMoviendoID =Movimientos.CuentaID
                            };
                            

                            // Redirigir a la página principal o a la página deseada
                            Response.Redirect("Main.aspx");
                        }
                        else
                        {
                            LblError.Text = "No se encontraron datos del usuario";
                            LblError.Visible = true;
                        }
                    }
                }



            }
        }
        private string ValidarFormulario(string usuario, string contrasena)
        {
            string MensajeErrorContrasena = ValidarContrasena(contrasena);
            if (MensajeErrorContrasena != null)
            {
                return MensajeErrorContrasena;
            }
            string MensajeErrorUsuario = ValidarUsuario(usuario);
            if (MensajeErrorUsuario != null)
            {
                return MensajeErrorUsuario;
            }
            return null;
        }
        private string ValidarUsuario(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            // Verificar que el correo no esté vacío ni exceda límites de longitud
            if (string.IsNullOrWhiteSpace(correo))
            {
                return "El correo no puede ser vació";
            }
            ;
            if (!System.Text.RegularExpressions.Regex.IsMatch(correo, patron))
            {
                return "Correo no válido";
            }
            ;
            return null; 
        }
        private string ValidarContrasena(string contrasena)
        {
            if (contrasena.Length < 8)
            {
                return "La contraseña es demasiado corta";
            }
            if ( contrasena.IsNullOrWhiteSpace())
            {
                return "La debes completar el campo contraseña";
            }
            return null;
        }
    }
}
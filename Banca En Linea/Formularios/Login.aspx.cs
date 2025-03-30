using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Banca_En_Linea.Data;
using Microsoft.Ajax.Utilities;

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
                // Aquí debes manejar la inserción de los datos en tu base de datos, incluyendo la lógica necesaria
                using (var context = new Easy_Pay_Entities())
                {
                    // Inserción de datos en la base de datos
                    long cedula = 206780934;//Convert.ToInt64(Session["Cedula"]);
                    //context.sp_Login(cedula, usuario, contrasena);
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
            if (System.Text.RegularExpressions.Regex.IsMatch(correo, patron))
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
using Banca_En_Linea.Data;
using System;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace Banca_En_Linea
{
    public partial class Main : Page 
    {

        protected void Page_Load(object sender, EventArgs e) 
        {
                if (!IsPostBack)
                {
                    // Verificar si los datos existen en la sesión
                    if (Session["DatosCliente"] != null)
                    {
                        // Obtener la cédula desde la sesión
                        var datosCliente = (DatosCliente)Session["DatosCliente"];
                        CargarDatosUsuario(Convert.ToInt64(datosCliente.Cedula));
                    }
                    else
                    {
                        // Manejar el caso cuando la sesión no contiene datos
                        // Podrías redirigir a una página de error o mostrar un mensaje
                        Response.Redirect("PaginaDeError.aspx");
                    }
                }
            
        }


        private void CargarDatosUsuario(long usuarioID)
        {
            try
            {
                // Verificar si los datos existen en la sesión
                if (Session["DatosCliente"] != null)
                {
                    // Obtener los datos desde la sesión
                    var datosCliente = (DatosCliente)Session["DatosCliente"];

                    // Asignar los valores a los controles
                    lblNombreCompleto.Text = $"{datosCliente.Nombre} {datosCliente.Apellido}";
                    lblEmail.Text = datosCliente.Correo;
                    lblFechaNacimiento.Text = datosCliente.FechaNacimiento.ToString("dd/MM/yyyy");
                    lblUsuario.Text = datosCliente.NombreUsuario;
                    lblDireccion.Text = datosCliente.Direccion;
                    lblTelefono.Text = datosCliente.Telefono;

                    // Actualizar el mensaje de bienvenida
                    cardHeader.InnerText = $"Welcome, {datosCliente.NombreUsuario}";
                    usernameLabel.InnerText = datosCliente.NombreUsuario;
                }
                else
                {
                    // Manejar el caso cuando no hay datos en la sesión
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('No se encontraron datos del cliente en la sesión.');", true);

                    // Alternativamente, podrías redirigir a una página de inicio de sesión o error
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier otro error
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    $"alert('Error al cargar datos desde la sesión: {ex.Message}');", true);
            }
        }


        //protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Validaciones básicas de los campos
        //        string correo = txtEmail.Text.Trim();
        //        string nombreUsuario = txtUsuario.Text.Trim();
        //        string direccion = txtDireccion.Text.Trim();
        //        string telefono = txtTelefono.Text.Trim();

        //        if (string.IsNullOrEmpty(correo) || !correo.Contains("@"))
        //        {

        //            lblMensaje.Text = "Por favor, ingresa un correo electrónico válido.";
        //            return;
        //        }

        //        if (string.IsNullOrEmpty(nombreUsuario))
        //        {
        //            lblMensaje.Text = "Por favor, ingresa un nombre de usuario.";
        //            return;
        //        }

        //        if (string.IsNullOrEmpty(direccion))
        //        {
        //            lblMensaje.Text = "Por favor, ingresa una dirección.";
        //            return;
        //        }

        //        if (string.IsNullOrEmpty(telefono) || telefono.Length != 10 || !telefono.All(char.IsDigit))
        //        {
        //            lblMensaje.Text = "Por favor, ingresa un número de teléfono válido de 10 dígitos.";
        //            return;
        //        }

        //        // Obtener el ID del usuario desde la sesión
        //        if (Session["DatosCliente"] != null)
        //        {
        //            var datosCliente = (DatosCliente)Session["DatosCliente"];
        //            long usuarioID = datosCliente.Cedula;

        //            // Llamar al método para actualizar el perfil
        //            bool exito = ActualizarPerfil(usuarioID, correo, nombreUsuario, direccion, telefono);

        //            if (exito)
        //            {
        //                lblMensaje.Text = "¡Perfil actualizado exitosamente!";
        //                lblMensaje.CssClass = "alert alert-success";
        //            }
        //            else
        //            {
        //                lblMensaje.Text = "Hubo un problema al actualizar el perfil. Intenta nuevamente.";
        //                lblMensaje.CssClass = "alert alert-danger";
        //            }
        //        }
        //        else
        //        {
        //            lblMensaje.Text = "No se encontraron datos del usuario en la sesión.";
        //            lblMensaje.CssClass = "alert alert-danger";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMensaje.Text = $"Error: {ex.Message}";
        //        lblMensaje.CssClass = "alert alert-danger";
        //    }
        //}

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas de los campos
                string correo = txtEmail.Text.Trim();
                string nombreUsuario = txtUsuario.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();

                if (string.IsNullOrEmpty(correo) || !correo.Contains("@"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa un correo electrónico válido.');", true);
                    return;
                }

                if (string.IsNullOrEmpty(nombreUsuario))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa un nombre de usuario.');", true);
                    return;
                }

                if (string.IsNullOrEmpty(direccion))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa una dirección.');", true);
                    return;
                }

                if (string.IsNullOrEmpty(telefono) || telefono.Length != 10 || !telefono.All(char.IsDigit))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa un número de teléfono válido de 10 dígitos.');", true);
                    return;
                }

                // Obtener el ID del usuario desde la sesión
                if (Session["DatosCliente"] != null)
                {
                    var datosCliente = (DatosCliente)Session["DatosCliente"];
                    long usuarioID = datosCliente.Cedula;

                    // Llamar al método para actualizar el perfil
                    bool exito = ActualizarPerfil(usuarioID, correo, nombreUsuario, direccion, telefono);

                    if (exito)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('¡Perfil actualizado exitosamente!');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Hubo un problema al actualizar el perfil. Intenta nuevamente.');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se encontraron datos del usuario en la sesión.');", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
        }

        private bool ActualizarPerfil(long usuarioID, string correo, string nombreUsuario, string direccion, string telefono)
        {
            using (var context = new Easy_Pay_Entities())
            {
                // Crear el parámetro de salida
                var resultadoParam = new ObjectParameter("Resultado", typeof(int));

                // Llamada al procedimiento almacenado sp_ActualizarCliente
                context.sp_ActualizarCliente(usuarioID, correo, nombreUsuario, direccion, telefono, resultadoParam);

                // Obtener el valor del parámetro de salida
                int resultado = (int)resultadoParam.Value;

                // Si el resultado es igual a 1, significa que la actualización fue exitosa
                return resultado == 1;
            }
        }

        protected void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            CambiarContrasena(Convert.ToInt64(Session["UsuarioID"]));
        }



        private void CambiarContrasena(long usuarioID)
        {
            
        }
    }
}
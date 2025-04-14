using Banca_En_Linea.Data;
using System;
using System.Collections.Generic;
using System.Data.Objects;
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
                if (Session["DatosCliente"] != null)
                {
                    // Obtener la cédula desde la sesión
                    var datosCliente = (DatosCliente)Session["DatosCliente"];
                    CargarDatosUsuario(Convert.ToInt64(datosCliente.Cedula));
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                LlenarCamposPerfil();
            }
        }
        private void CargarDatosUsuario(long usuarioID)
        {
            try
            {
                if (Session["DatosCliente"] != null || Session["Tarjetas"] != null || Session["Cuentas"] != null)
                {
                    var datosCliente = (DatosCliente)Session["DatosCliente"];
                    lblNombreCompleto.Text = $"{datosCliente.Nombre} {datosCliente.Apellido}";
                    lblEmail.Text = datosCliente.Correo;
                    lblFechaNacimiento.Text = datosCliente.FechaNacimiento.ToString("dd/MM/yyyy");
                    lblUsuario.Text = datosCliente.NombreUsuario;
                    lblDireccion.Text = datosCliente.Direccion;
                    lblTelefono.Text = datosCliente.Telefono;
                    cardHeader.InnerText = $"Welcome, {datosCliente.NombreUsuario}";
                    usernameLabel.InnerText = datosCliente.NombreUsuario;
                    List<Tarjetas> tarjetas = (List<Tarjetas>)Session["Tarjetas"];
                    rptTarjetas.DataSource = tarjetas;
                    rptTarjetas.DataBind();
                    List<Cuentas> cuentas = (List<Cuentas>)Session["Cuentas"];
                    rptCuentas.DataSource = cuentas;
                    rptCuentas.DataBind();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('No se encontraron datos del cliente en la sesión.');", true);
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    $"alert('Error al cargar datos desde la sesión: {ex.Message}');", true);
            }
        }
        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
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
                if (string.IsNullOrEmpty(telefono) || telefono.Length != 8 || !telefono.All(char.IsDigit))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa un número de teléfono válido de 10 dígitos.');", true);
                    return;
                }
                if (Session["DatosCliente"] != null)
                {
                    var datosCliente = (DatosCliente)Session["DatosCliente"];
                    long usuarioID = datosCliente.Cedula;
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
                var resultadoParam = new ObjectParameter("Resultado", typeof(int));
                context.sp_ActualizarCliente(usuarioID, correo, nombreUsuario, direccion, telefono, resultadoParam);
                int resultado = (int)resultadoParam.Value;
                if (resultado == 1)
                {
                    ActualizarSesionDatosUsuario(correo);
                    return true;
                }
                return false;
            }
        }
        private void ActualizarSesionDatosUsuario(string correo)
        {
            using (var context = new Easy_Pay_Entities())
            {
                var cliente = context.sp_ObtenerClientePorCedula(correo).FirstOrDefault();
                if (cliente != null)
                {
                    Session["DatosCliente"] = new DatosCliente
                    {
                        Cedula = cliente.Cedula,
                        Nombre = cliente.Nombre,
                        Apellido = cliente.Apellido,
                        NombreUsuario = cliente.NombreUsuario,
                        Correo = cliente.Correo,
                        FechaNacimiento = cliente.FechaNacimiento ?? DateTime.MinValue,
                        Direccion = cliente.Direccion ?? "No disponible",
                        Telefono = cliente.Telefono ?? "No disponible"
                    };
                    var datosCliente = (DatosCliente)Session["DatosCliente"];
                    CargarDatosUsuario(Convert.ToInt64(datosCliente.Cedula));
                }
                else
                {
                    Session["DatosCliente"] = null;
                }
            }
        }
        protected void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                string contrasenaActual = txtContrasenaActual.Text.Trim();
                string nuevaContrasena = txtNuevaContrasena.Text.Trim();
                string confirmarContrasena = txtConfirmarContrasena.Text.Trim();
                if (string.IsNullOrEmpty(contrasenaActual))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, ingresa tu contraseña actual.');", true);
                    return;
                }
                if (string.IsNullOrEmpty(nuevaContrasena) || nuevaContrasena.Length < 6)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La nueva contraseña debe tener al menos 6 caracteres.');", true);
                    return;
                }
                if (nuevaContrasena != confirmarContrasena)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La nueva contraseña y la confirmación no coinciden.');", true);
                    return;
                }
                if (Session["DatosCliente"] != null)
                {
                    var datosCliente = (DatosCliente)Session["DatosCliente"];
                    long usuarioID = datosCliente.Cedula;
                    if (VerificarContrasenaActual(usuarioID, contrasenaActual))
                    {
                        if (CambiarContrasena(usuarioID, nuevaContrasena))
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('¡Contraseña cambiada exitosamente!');", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Hubo un problema al cambiar la contraseña. Intenta nuevamente.');", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La contraseña actual es incorrecta.');", true);
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
        private bool VerificarContrasenaActual(long usuarioID, string contrasenaActual)
        {
            using (var context = new Easy_Pay_Entities())
            {
                var resultadoParam = new ObjectParameter("Resultado", typeof(int));
                context.sp_ConsultarContrasena(usuarioID, contrasenaActual, resultadoParam);
                int resultado = (int)resultadoParam.Value;
                return resultado == 1;
            }
        }
        private bool CambiarContrasena(long usuarioID, string nuevaContrasena)
        {
            using (var context = new Easy_Pay_Entities())
            {
                var resultadoParam = new ObjectParameter("Resultado", typeof(int));
                context.sp_CambiarContrasena(usuarioID, nuevaContrasena, resultadoParam);
                int resultado = (int)resultadoParam.Value;
                return resultado == 1;
            }
        }
        private void LlenarCamposPerfil()
        {
            var datosCliente = (DatosCliente)Session["DatosCliente"];
            if (Session["DatosCliente"] != null)
            {
                txtEmail.Text = datosCliente.Correo.ToString();
                txtUsuario.Text = datosCliente.NombreUsuario.ToString();
                txtDireccion.Text = datosCliente.Direccion.ToString();
                txtTelefono.Text = datosCliente.Telefono.ToString();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se encontraron datos del usuario en la sesión.');", true);
            }
        }
    }
}
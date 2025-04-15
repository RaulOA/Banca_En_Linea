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
                    // Obtener la cédula desde la sesión y cargar los datos del usuario  
                    var datosCliente = (DatosCliente)Session["DatosCliente"];
                    CargarDatosUsuario(Convert.ToInt64(datosCliente.Cedula));
                    // Llenar los campos del perfil en caso de no postback  
                    LlenarCamposPerfil();
                }
                else
                {
                    // Redirigir al login si no hay datos en la sesión  
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void CargarDatosUsuario(long usuarioID)
        {
            try
            {
                if (Session["DatosCliente"] != null && Session["Tarjetas"] != null && Session["Cuentas"] != null)
                {
                    var datosCliente = (DatosCliente)Session["DatosCliente"];
                    // Asignar datos del cliente a los controles de la interfaz
                    lblNombreCompleto.Text = $"{datosCliente.Nombre} {datosCliente.Apellido}";
                    lblEmail.Text = datosCliente.Correo;
                    lblFechaNacimiento.Text = datosCliente.FechaNacimiento.ToString("dd/MM/yyyy");
                    lblUsuario.Text = datosCliente.NombreUsuario;
                    lblDireccion.Text = datosCliente.Direccion;
                    lblTelefono.Text = datosCliente.Telefono;

                    // Cargar tarjetas y cuentas
                    rptTarjetas.DataSource = (List<Tarjetas>)Session["Tarjetas"];
                    rptTarjetas.DataBind();
                    rptCuentas.DataSource = (List<Cuentas>)Session["Cuentas"];
                    rptCuentas.DataBind();
                }
                else
                {
                    MostrarAlerta("No se encontraron datos del cliente en la sesión.");
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta($"Error al cargar datos desde la sesión: {ex.Message}");
            }
        }

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar entradas del formulario
                if (!ValidarCorreo(txtEmail.Text.Trim()) || !ValidarTexto(txtUsuario.Text.Trim(), "nombre de usuario") ||
                    !ValidarTexto(txtDireccion.Text.Trim(), "dirección") || !ValidarTelefono(txtTelefono.Text.Trim()))
                {
                    return;
                }

                if (Session["DatosCliente"] != null)
                {
                    var datosCliente = (DatosCliente)Session["DatosCliente"];
                    long usuarioID = datosCliente.Cedula;

                    // Actualizar perfil del usuario
                    if (ActualizarPerfil(usuarioID, txtEmail.Text.Trim(), txtUsuario.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim()))
                    {
                        MostrarAlerta("¡Perfil actualizado exitosamente!");
                    }
                    else
                    {
                        MostrarAlerta("Hubo un problema al actualizar el perfil. Intenta nuevamente.");
                    }
                }
                else
                {
                    MostrarAlerta("No se encontraron datos del usuario en la sesión.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta($"Error: {ex.Message}");
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
                    // Actualizar datos del cliente en la sesión
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

                    // Recargar datos del usuario
                    CargarDatosUsuario(Convert.ToInt64(cliente.Cedula));
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
                // Validar entradas de contraseña
                if (!ValidarTexto(txtContrasenaActual.Text.Trim(), "contraseña actual") ||
                    !ValidarNuevaContrasena(txtNuevaContrasena.Text.Trim(), txtConfirmarContrasena.Text.Trim()))
                {
                    return;
                }

                if (Session["DatosCliente"] != null)
                {
                    var datosCliente = (DatosCliente)Session["DatosCliente"];
                    long usuarioID = datosCliente.Cedula;

                    // Verificar contraseña actual
                    if (!VerificarContrasenaActual(usuarioID, txtContrasenaActual.Text.Trim()))
                    {
                        MostrarAlerta("La contraseña actual no es correcta.");
                        return;
                    }

                    // Cambiar contraseña
                    if (CambiarContrasena(usuarioID, txtNuevaContrasena.Text.Trim()))
                    {
                        MostrarAlerta("¡Contraseña cambiada exitosamente!");
                    }
                    else
                    {
                        MostrarAlerta("Hubo un problema al cambiar la contraseña. Intenta nuevamente.");
                    }
                }
                else
                {
                    MostrarAlerta("No se encontraron datos del usuario en la sesión.");
                }
            }
            catch (Exception ex)
            {
                MostrarAlerta($"Error: {ex.Message}");
            }
        }

        private bool VerificarContrasenaActual(long usuarioID, string contrasenaActual)
        {
            using (var context = new Easy_Pay_Entities())
            {
                var resultadoParam = new ObjectParameter("Resultado", typeof(int));
                context.sp_ConsultarContrasena(usuarioID, contrasenaActual, resultadoParam);
                return (int)resultadoParam.Value == 1;
            }
        }

        private bool CambiarContrasena(long usuarioID, string nuevaContrasena)
        {
            using (var context = new Easy_Pay_Entities())
            {
                var resultadoParam = new ObjectParameter("Resultado", typeof(int));
                context.sp_CambiarContrasena(usuarioID, nuevaContrasena, resultadoParam);
                return (int)resultadoParam.Value == 1;
            }
        }

        private void LlenarCamposPerfil()
        {
            if (Session["DatosCliente"] != null)
            {
                var datosCliente = (DatosCliente)Session["DatosCliente"];
                // Llenar campos del perfil con los datos del cliente
                txtEmail.Text = datosCliente.Correo;
                txtUsuario.Text = datosCliente.NombreUsuario;
                txtDireccion.Text = datosCliente.Direccion;
                txtTelefono.Text = datosCliente.Telefono;
            }
            else
            {
                MostrarAlerta("No se encontraron datos del usuario en la sesión.");
            }
        }

        // Métodos auxiliares para validaciones y alertas
        private bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrEmpty(correo) || !correo.Contains("@"))
            {
                MostrarAlerta("Por favor, ingresa un correo electrónico válido.");
                return false;
            }
            return true;
        }

        private bool ValidarTexto(string texto, string campo)
        {
            if (string.IsNullOrEmpty(texto))
            {
                MostrarAlerta($"Por favor, ingresa un {campo}.");
                return false;
            }
            return true;
        }

        private bool ValidarTelefono(string telefono)
        {
            if (string.IsNullOrEmpty(telefono) || telefono.Length != 8 || !telefono.All(char.IsDigit))
            {
                MostrarAlerta("Por favor, ingresa un número de teléfono válido de 8 dígitos.");
                return false;
            }
            return true;
        }

        private bool ValidarNuevaContrasena(string nuevaContrasena, string confirmarContrasena)
        {
            if (string.IsNullOrEmpty(nuevaContrasena) || nuevaContrasena.Length < 6)
            {
                MostrarAlerta("La nueva contraseña debe tener al menos 6 caracteres.");
                return false;
            }

            if (!nuevaContrasena.Any(char.IsUpper))
            {
                MostrarAlerta("La nueva contraseña debe contener al menos una letra mayúscula.");
                return false;
            }

            if (!nuevaContrasena.Any(char.IsLower))
            {
                MostrarAlerta("La nueva contraseña debe contener al menos una letra minúscula.");
                return false;
            }

            if (!nuevaContrasena.Any(char.IsDigit))
            {
                MostrarAlerta("La nueva contraseña debe contener al menos un número.");
                return false;
            }

            if (!nuevaContrasena.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                MostrarAlerta("La nueva contraseña debe contener al menos un símbolo.");
                return false;
            }

            if (nuevaContrasena != confirmarContrasena)
            {
                MostrarAlerta("La nueva contraseña y la confirmación no coinciden.");
                return false;
            }

            return true;
        }

        private void MostrarAlerta(string mensaje)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensaje}');", true);
        }

        protected void btnTransferirSaldo_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            string telefonoReceptor = txtTelefonoReceptor.Text.Trim();
            string contrasenaUsuario = txtContrasenaUsuario.Text.Trim();
            string montoTexto = txtSaldoTransferir.Text.Trim();

            if (string.IsNullOrEmpty(telefonoReceptor) || string.IsNullOrEmpty(contrasenaUsuario) || string.IsNullOrEmpty(montoTexto))
            {
                MostrarAlerta("Todos los campos son obligatorios.");
                return;
            }

            // Validar monto numérico
            if (!decimal.TryParse(montoTexto, out decimal montoTransferir) || montoTransferir <= 0)
            {
                MostrarAlerta("Por favor, ingresa un monto válido para transferir.");
                return;
            }

            using (var context = new Easy_Pay_Entities())
            {
                // Verificar existencia del receptor
                var resultadoParam = new ObjectParameter("Resultado", typeof(int));
                var cedulaReceptorParam = new ObjectParameter("Cedula", typeof(long));

                context.sp_VerificarTelefono(telefonoReceptor, cedulaReceptorParam, new ObjectParameter("Nombre", typeof(string)), new ObjectParameter("Apellido", typeof(string)), resultadoParam);

                if ((int)resultadoParam.Value != 1)
                {
                    MostrarAlerta("El número de teléfono del receptor no es válido.");
                    return;
                }

                // Obtener cédula del remitente
                var datosCliente = (DatosCliente)Session["DatosCliente"];
                long cedulaCliente = datosCliente.Cedula;
                long cedulaReceptor = (long)cedulaReceptorParam.Value;

                // Ejecutar la transferencia de saldo
                var resultadoTransferenciaParam = new ObjectParameter("ResultadoTransferencia", typeof(int));
                context.sp_TransferirSaldo(cedulaCliente, cedulaReceptor, montoTransferir, resultadoTransferenciaParam);

                int resultadoTransferencia = (int)resultadoTransferenciaParam.Value;

                switch (resultadoTransferencia)
                {
                    case 1:
                        // Actualizar saldo en sesión
                        var cuenta = (Cuentas)Session["Cuentas"];
                        if (cuenta != null)
                        {
                            cuenta.Saldo -= montoTransferir;
                            Session["Cuentas"] = cuenta;
                        }

                        MostrarAlerta("Transferencia realizada exitosamente.");
                        break;

                    case 0:
                        MostrarAlerta("Saldo insuficiente para realizar la transferencia.");
                        break;

                    case -1:
                        MostrarAlerta("No se encontró la cuenta del remitente.");
                        break;

                    case -2:
                        MostrarAlerta("No se encontró la cuenta del receptor.");
                        break;

                    default:
                        MostrarAlerta("Hubo un problema al realizar la transferencia. Intenta nuevamente.");
                        break;
                }
            }
        }
    }
}

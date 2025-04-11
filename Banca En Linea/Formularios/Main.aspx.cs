using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Banca_En_Linea.Data;

namespace Banca_En_Linea
{
    public partial class Main : Page //IMPORTANTEEE Se debe descomentar esta linea cuando ya se pueda logear con un usuario
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        if (Session["Cedula"] != null)
        //        {
        //            CargarDatosUsuario(Convert.ToInt64(Session["Cedula"]));
        //        }
        //        else
        //        {
        //            // Redirigir a login si no hay sesión
        //            Response.Redirect("Login.aspx");
        //        }
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e) //Se debe eliminar esta linea cuando ya se pueda logear con un usuario
        {
            if (!IsPostBack)
            {
                //CargarDatosUsuario(Convert.ToInt64(Session["DatosCliente"].));
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
        }

        //private void CargarDatosUsuario(long usuarioID)
        //{
        //    // Obtener la cadena de conexión directa desde el contexto de Entity Framework
        //    using (var context = new Easy_Pay_Entities())
        //    {
        //        string sqlConnectionString = context.Database.Connection.ConnectionString;

        //        using (SqlConnection connection = new SqlConnection(sqlConnectionString))
        //        {
        //            try
        //            {
        //                SqlCommand command = new SqlCommand("ManejoUsuarios", connection);
        //                command.CommandType = CommandType.StoredProcedure;

        //                // Parámetros de entrada
        //                command.Parameters.Add(new SqlParameter("@Accion", "CONSULTAR"));
        //                command.Parameters.Add(new SqlParameter("@CEDULA_CLIENTE", usuarioID));

        //                // Parámetros de salida
        //                SqlParameter resultado = new SqlParameter("@Resultado", SqlDbType.Bit);
        //                resultado.Direction = ParameterDirection.Output;
        //                command.Parameters.Add(resultado);

        //                SqlParameter mensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 200);
        //                mensaje.Direction = ParameterDirection.Output;
        //                command.Parameters.Add(mensaje);

        //                connection.Open();
        //                SqlDataReader reader = command.ExecuteReader();

        //                if (reader.HasRows && reader.Read())
        //                {
        //                    // Asignar datos a los controles
        //                    lblNombreCompleto.Text = $"{reader["Nombre"]} {reader["Apellido"]}";
        //                    lblEmail.Text = reader["Email"].ToString();
        //                    lblFechaNacimiento.Text = Convert.ToDateTime(reader["FechaNacimiento"]).ToString("dd/MM/yyyy");
        //                    lblUsuario.Text = reader["NombreUsuario"].ToString();
        //                    lblDireccion.Text = reader["Direccion"].ToString();
        //                    lblTelefono.Text = reader["Telefono"].ToString();

        //                    // Actualizar el welcome message
        //                    cardHeader.InnerText = $"Welcome, {reader["NombreUsuario"]}";
        //                    usernameLabel.InnerText = reader["NombreUsuario"].ToString();

        //                    // Actualizar la imagen si existe
        //                    if (!string.IsNullOrEmpty(reader["Foto"].ToString()))
        //                    {
        //                        imgPerfil.ImageUrl = ResolveUrl($"~/Images/Users/{reader["Foto"]}");
        //                    }
        //                }
        //                reader.Close();

        //                // Verificar resultado de la operación
        //                if (!Convert.ToBoolean(resultado.Value))
        //                {
        //                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //                        $"alert('{mensaje.Value.ToString()}');", true);
        //                }
        //            }
        //            catch (SqlException sqlEx)
        //            {
        //                // Manejo específico para errores de SQL
        //                ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //                    $"alert('Error de base de datos: {sqlEx.Message}');", true);
        //            }
        //            catch (Exception ex)
        //            {
        //                // Manejo de otros errores
        //                ClientScript.RegisterStartupScript(this.GetType(), "alert",
        //                    $"alert('Error al cargar datos: {ex.Message}');", true);
        //            }
        //        }
        //    }
        //}
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
        private long ObtenerCedulaUsuario() //IMPORTARTE  se debe deliminar esta linea cuando se pueda logear con un usuario.
        {
            // Implementa según tu sistema de autenticación
            // Ejemplo: return ((Usuario)Session["Usuario"]).Cedula;
            return 206780934; // Temporal para pruebas
        }

        protected void btnGuardarPerfil_Click(object sender, EventArgs e)
        {
            ActualizarPerfil(Convert.ToInt64(Session["UsuarioID"]));
        }

        protected void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            CambiarContrasena(Convert.ToInt64(Session["UsuarioID"]));
        }

        private void ActualizarPerfil(long usuarioID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Easy_Pay_Entities"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("ManejoUsuarios", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros para actualización
                    command.Parameters.Add(new SqlParameter("@Accion", "ACTUALIZAR"));
                    command.Parameters.Add(new SqlParameter("@UsuarioID", usuarioID));
                    command.Parameters.Add(new SqlParameter("@Email", txtEmail.Text.Trim()));
                    command.Parameters.Add(new SqlParameter("@NombreUsuario", txtUsuario.Text.Trim()));
                    command.Parameters.Add(new SqlParameter("@Direccion", txtDireccion.Text.Trim()));
                    command.Parameters.Add(new SqlParameter("@Telefono", txtTelefono.Text.Trim()));

                    // Parámetros de salida
                    SqlParameter resultado = new SqlParameter("@Resultado", SqlDbType.Bit);
                    resultado.Direction = ParameterDirection.Output;
                    command.Parameters.Add(resultado);

                    SqlParameter mensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 200);
                    mensaje.Direction = ParameterDirection.Output;
                    command.Parameters.Add(mensaje);

                    connection.Open();
                    command.ExecuteNonQuery();

                    if (Convert.ToBoolean(resultado.Value))
                    {
                        // Actualizar datos en pantalla
                        CargarDatosUsuario(usuarioID);
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                            $"alert('{mensaje.Value.ToString()}');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert",
                            $"alert('Error: {mensaje.Value.ToString()}');", true);
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        $"alert('Error al actualizar perfil: {ex.Message}');", true);
                }
            }
        }

        private void CambiarContrasena(long usuarioID)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Easy_Pay_Entities"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("USP_MANEJO_USUARIO", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros para cambio de contraseña
                    command.Parameters.Add(new SqlParameter("@Accion", "CAMBIAR_CONTRASENA"));
                    command.Parameters.Add(new SqlParameter("@UsuarioID", usuarioID));
                    command.Parameters.Add(new SqlParameter("@ContrasenaActual", txtContrasenaActual.Text.Trim()));
                    command.Parameters.Add(new SqlParameter("@NuevaContrasena", txtNuevaContrasena.Text.Trim()));

                    // Parámetros de salida
                    SqlParameter resultado = new SqlParameter("@Resultado", SqlDbType.Bit);
                    resultado.Direction = ParameterDirection.Output;
                    command.Parameters.Add(resultado);

                    SqlParameter mensaje = new SqlParameter("@Mensaje", SqlDbType.VarChar, 200);
                    mensaje.Direction = ParameterDirection.Output;
                    command.Parameters.Add(mensaje);

                    connection.Open();
                    command.ExecuteNonQuery();

                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        $"alert('{mensaje.Value.ToString()}');", true);

                    if (Convert.ToBoolean(resultado.Value))
                    {
                        // Limpiar campos si fue exitoso
                        txtContrasenaActual.Text = "";
                        txtNuevaContrasena.Text = "";
                        txtConfirmarContrasena.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        $"alert('Error al cambiar contraseña: {ex.Message}');", true);
                }
            }
        }
    }
}
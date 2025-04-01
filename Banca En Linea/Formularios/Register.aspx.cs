using Banca_En_Linea.Data;
using System;
using System.Linq;
using System.Web.UI;

namespace Banca_En_Linea
{
    public partial class _Register : Page
    {
        //hola
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtNacimiento.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string cedula = TxtCedula.Text;
            string nombre = TxtNombre.Text;
            string apellido = TxtApellido.Text;
            string usuario = TxtUsuario.Text;
            string contrasena = TxtPass1.Text;
            string confirmacion = TxtPass2.Text;
            DateTime fechaNacimiento = Convert.ToDateTime(TxtNacimiento.Text);
            string direccion = TxtDireccion.Text;
            string telefono = TxtTelefono.Text;
            string correo = TxtCorreo.Text;
            string preguntaSeguridad = DdlPregunta.SelectedItem.Value;
            string respuestaSeguridad = TxtRespuesta.Text;
            DateTime fechaCreacion = DateTime.Now;
            DateTime fechaModificacion = DateTime.Now;
            DateTime fechaUltimoIngreso = DateTime.Now;


            // habilitar la visualizacion del mensaje de error en caso de que exista uno y mostrar el mensaje, o caso contrario insertar el cliente
            string error = ValidarFormulario(cedula, nombre, apellido, contrasena, confirmacion, fechaNacimiento, direccion, telefono, correo, respuestaSeguridad);
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
                    context.InsertarCliente(string.IsNullOrWhiteSpace(cedula) ? 0 : Convert.ToInt64(cedula), nombre, apellido, usuario, contrasena, fechaNacimiento, direccion, telefono, correo, null, fechaCreacion, fechaModificacion, fechaUltimoIngreso);
                    // Guardar la pregunta y respuesta de seguridad en la base de datos aquí, si es necesario
                }

            }

        }

        private string ValidarFormulario(string cedula, string nombre, string apellido, string contrasena, string confirmacion, DateTime fechaNacimiento, string direccion, string telefono, string correo, string respuestaSeguridad)
        {
            if (!ValidarCedula(cedula))
            {
                return "La cédula ingresada no es válida.";
            }

            if (!ValidarNombre(nombre))
            {
                return "El nombre ingresado no es válido.";
            }

            if (!ValidarNombre(apellido))
            {
                return "El apellido ingresado no es válido.";
            }

            if (!ValidarContrasena(contrasena))
            {
                return "La contraseña ingresada no es válida.";
            }

            if (!ValidarConfirmacionContrasena(contrasena, confirmacion))
            {
                return "La confirmación de la contraseña no coincide.";
            }

            if (!ValidarFechaNacimiento(fechaNacimiento))
            {
                return "La fecha de nacimiento ingresada no es válida.";
            }

            if (!ValidarDireccion(direccion))
            {
                return "La dirección ingresada no es válida.";
            }

            if (!ValidarTelefono(telefono))
            {
                return "El teléfono ingresado no es válido.";
            }

            if (!ValidarCorreo(correo))
            {
                return "El correo electrónico ingresado no es válido.";
            }

            if (!ValidarRespuestaSeguridad(respuestaSeguridad))
            {
                return "La respuesta de seguridad ingresada no es válida.";
            }

            return null;
        }

        private bool ValidarCedula(string cedula)
        {
            // Verifica que tenga al menos 9 caracteres y que todos sean dígitos.
            return cedula.Length >= 9 && cedula.All(char.IsDigit);
        }

        private bool ValidarNombre(string nombre)
        {
            // Verificar que el nombre no esté vacío y tenga una longitud razonable
            if (string.IsNullOrWhiteSpace(nombre) || nombre.Length < 3 || nombre.Length > 50)
            {
                return false;
            }

            // Verificar que el nombre solo contenga letras y espacios
            foreach (char c in nombre)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }

            return true;
        }
        private bool ValidarContrasena(string contrasena)
        {
            // Verificar que la contraseña tenga al menos 8 caracteres
            if (contrasena.Length < 8)
            {
                return false;
            }
            // Verificar que la contraseña contenga al menos un número
            if (!contrasena.Any(char.IsDigit))
            {
                return false;
            }
            // Verificar que la contraseña contenga al menos una letra mayúscula
            if (!contrasena.Any(char.IsUpper))
            {
                return false;
            }
            // Verificar que la contraseña contenga al menos una letra minúscula
            if (!contrasena.Any(char.IsLower))
            {
                return false;
            }
            return true;
        }

        private bool ValidarConfirmacionContrasena(string contrasena, string confirmacion)
        {
            return contrasena == confirmacion;
        }

        private bool ValidarFechaNacimiento(DateTime fechaNacimiento)
        {
            // Verificar que la fecha de nacimiento sea anterior a la fecha actual
            if (fechaNacimiento >= DateTime.Now)
            {
                return false;
            }

            // Verificar que el usuario tenga al menos 18 años
            int edad = DateTime.Now.Year - fechaNacimiento.Year;
            if (fechaNacimiento > DateTime.Now.AddYears(-edad))
            {
                edad--;
            }

            return edad >= 18;
        }

        // Agregar más métodos de validación según sea necesario (direccion, telefono correo electronico respuesta)
        private bool ValidarDireccion(string direccion)
        {
            // Verificar que la dirección no esté vacía y tenga una longitud razonable
            if (string.IsNullOrWhiteSpace(direccion) || direccion.Length < 5 || direccion.Length > 100)
            {
                return false;
            }
            return true;
        }
        private bool ValidarTelefono(string telefono)
        {
            // Verificar que el teléfono no esté vacío y tenga una longitud razonable
            if (string.IsNullOrWhiteSpace(telefono) || telefono.Length < 8 || telefono.Length > 15)
            {
                return false;
            }
            // Verificar que el teléfono contenga solo números
            foreach (char c in telefono)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidarCorreo(string correo)
        {
            // Verificar que el correo no esté vacío ni exceda límites de longitud
            if (string.IsNullOrWhiteSpace(correo) || correo.Length > 320)
            {
                return false;
            }

            // Usar una expresión regular para validar el formato del correo
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(correo, patron);
        }

        private bool ValidarRespuestaSeguridad(string respuestaSeguridad)
        {
            // Verificar que la respuesta de seguridad no esté vacía y tenga una longitud razonable
            if (string.IsNullOrWhiteSpace(respuestaSeguridad) || respuestaSeguridad.Length < 3 || respuestaSeguridad.Length > 50)
            {
                return false;
            }
            return true;
        }



    }
}


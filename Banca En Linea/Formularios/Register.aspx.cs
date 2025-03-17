using Banca_En_Linea.Data;
using System;
using System.Linq;
using System.Web.UI;

namespace Banca_En_Linea
{
    public partial class _Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            long cedula = Convert.ToInt64(TxtCedula.Text);
            string nombre = TxtNombre.Text;
            string apellido = TxtApellido.Text;
            string usuario = TxtUsuario.Text;
            string contrasena = TxtPass1.Text;
            string confirmacion = TxtPass2.Text;
            DateTime fechaNacimiento = Convert.ToDateTime(TxtNacimiento.Text);
            string direccion = TxtDireccion.Text;
            string telefono = TxtTelefono.Text;
            string correo = TxtCorreo.Text;
            string preguntaSeguridad = DdlPregunta.SelectedItem.Text;
            string respuestaSeguridad = TxtRespuesta.Text;
            DateTime fechaCreacion = DateTime.Now;
            DateTime fechaModificacion = DateTime.Now;
            DateTime fechaUltimoIngreso = DateTime.Now;


            // habilitar la visualizacion del mensaje de error en caso de que exista uno y mostrar el mensaje, o caso contrario insertar el cliente
            string error = ValidarFormulario(cedula, nombre, apellido, contrasena, confirmacion, fechaNacimiento, direccion, telefono, correo, preguntaSeguridad, respuestaSeguridad);
            if (error != null)
            {
                LblError.Text = error;
                LblError.Visible = true;
                return;
            }




            // Aquí debes manejar la inserción de los datos en tu base de datos, incluyendo la lógica necesaria
            using (var context = new Easy_Pay_Entities())
            {
                context.InsertarCliente(cedula, nombre, apellido, usuario, contrasena, fechaNacimiento, direccion, telefono, correo, null, fechaCreacion, fechaModificacion, fechaUltimoIngreso);
                // Guardar la pregunta y respuesta de seguridad en la base de datos aquí, si es necesario
            }

        }

        private string ValidarFormulario(long cedula, string nombre, string apellido, string contrasena, string confirmacion, DateTime fechaNacimiento, string direccion, string telefono, string correo, string preguntaSeguridad, string respuestaSeguridad)
        {
            if (!ValidarCedula(cedula.ToString()))
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

            if (!ValidarPreguntaSeguridad(preguntaSeguridad))
            {
                return "La pregunta de seguridad ingresada no es válida.";
            }

            if (!ValidarRespuestaSeguridad(respuestaSeguridad))
            {
                return "La respuesta de seguridad ingresada no es válida.";
            }

            return null;
        }
        private bool ValidarCedula(string cedula)
        {
            if (cedula.Length != 9)
            {
                return false;
            }
            int digitoVerificador = int.Parse(cedula.Substring(8, 1));
            int suma = 0;
            for (int i = 0; i < 8; i++)
            {
                int digito = int.Parse(cedula.Substring(i, 1));
                if (i % 2 == 0)
                {
                    digito *= 2;
                    if (digito > 9)
                    {
                        digito -= 9;
                    }
                }
                suma += digito;
            }
            int residuo = suma % 10;
            int resultado = residuo == 0 ? 0 : 10 - residuo;
            return resultado == digitoVerificador;
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
            // Verificar que la dirección contenga al menos un número
            if (!direccion.Any(char.IsDigit))
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
            // Verificar que el correo no esté vacío y tenga una longitud razonable
            if (string.IsNullOrWhiteSpace(correo) || correo.Length < 5 || correo.Length > 50)
            {
                return false;
            }
            // Verificar que el correo contenga un @
            if (!correo.Contains("@"))
            {
                return false;
            }
            // Verificar que el correo contenga un .
            if (!correo.Contains("."))
            {
                return false;
            }
            return true;
        }
        private bool ValidarPreguntaSeguridad(string preguntaSeguridad)
        {
            // Verificar que la pregunta de seguridad no esté vacía y tenga una longitud razonable
            if (string.IsNullOrWhiteSpace(preguntaSeguridad) || preguntaSeguridad.Length < 5 || preguntaSeguridad.Length > 50)
            {
                return false;
            }
            return true;
        }
        private bool ValidarRespuestaSeguridad(string respuestaSeguridad)
        {
            // Verificar que la respuesta de seguridad no esté vacía y tenga una longitud razonable
            if (string.IsNullOrWhiteSpace(respuestaSeguridad) || respuestaSeguridad.Length < 5 || respuestaSeguridad.Length > 50)
            {
                return false;
            }
            return true;
        }



    }
}


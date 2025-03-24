using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Banca_En_Linea.Data;

namespace Banca_En_Linea
{
    public partial class _AddTarjeta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddTarjeta_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string nombre = txtNombre.Text;
            string numeroTarjeta = txtNumeroTarjeta.Text;
            string fechaVencimiento = txtFechaVencimiento.Text;
            string cvv = txtcvv.Text;

            // habilitar la visualizacion del mensaje de error en caso de que exista uno y mostrar el mensaje, o caso contrario insertar el cliente
            string error = ValidarFormulario(numeroTarjeta, fechaVencimiento, cvv);
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
                }
            }
        }

        private string ValidarFormulario(string numeroTarjeta, string fechaVencimiento, string cvv)
        {
            if (ValidarTarjeta(numeroTarjeta))
            {
                return "El número de tarjeta no puede estar vacío";
            }
            if (string.IsNullOrWhiteSpace(fechaVencimiento))
            {
                return "La fecha de vencimiento no puede estar vacía";
            }
            if (string.IsNullOrWhiteSpace(cvv))
            {
                return "El CVV no puede estar vacío";
            }
            return null;
        }
        private bool ValidarTarjeta(string numeroTarjeta)
        {
            if (numeroTarjeta.Length != 16)
            {
                return false;
            }
            return true;
        }
        private bool ValidarCVV(string cvv)
        {
            if (cvv.Length != 3)
            {
                return false;
            }
            return true;
        }
        private bool ValidarNombre(string Nombre)
        {
            if (Nombre != "nomb")
            {
                return false;
            }
            return true;
        }
        private bool ValidarFechaVencimiento(DateTime date)
        {
            if (date >= DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
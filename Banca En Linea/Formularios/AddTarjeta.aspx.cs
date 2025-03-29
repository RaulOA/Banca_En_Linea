using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Banca_En_Linea.Data;
using Microsoft.Ajax.Utilities;

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
            int cvv = int.Parse(txtcvv.Text);

            // habilitar la visualizacion del mensaje de error en caso de que exista uno y mostrar el mensaje, o caso contrario insertar el cliente
            string error = ValidarFormulario(numeroTarjeta, fechaVencimiento, cvv,nombre);
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
                    DateTime Vencimiento;
                    DateTime.TryParseExact(fechaVencimiento, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out Vencimiento);
                    int id = DateTime.Now.ToString("yyyyMMddHHmmss").GetHashCode();
                    long cedula = 206780934;//Convert.ToInt64(Session["Cedula"]);
                    DateTime fechaCreacion = DateTime.Now;
                    context.sp_CreateTarjetas(id,numeroTarjeta, Vencimiento, fechaCreacion, cvv, cedula);
                }
                
            }
        }

        private string ValidarFormulario(string numeroTarjeta, string fechaVencimiento, int cvv, string nombre)
        {
            if (!ValidarTarjeta(numeroTarjeta))
            {
                return "El número de tarjeta no puede estar vacío";
            }
            if (!ValidarFechaVencimiento(fechaVencimiento))
            {
                return "La fecha de vencimiento no puede estar vacia o ser menor a la actual";
            }
            if (!ValidarCVV(cvv))
            {
                return "El CVV debe tener 3 dígitos";
            }
            if (!ValidarNombre(nombre))
            {
                return "El nombre no puede estar vacío";
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
        private bool ValidarCVV(int cvv)
        {
            if (cvv.ToString().Length != 3)
            {
                return false;
            }
            return true;
        }
        private bool ValidarNombre(string Nombre)
        {
            if (Nombre.IsNullOrWhiteSpace() || Nombre.Length < 3 || Nombre.Length >50)
            {
                return false;
            }
            return true;
        }
        private bool ValidarFechaVencimiento(string date)
        {
            DateTime FechaVencimiento;
            DateTime.TryParseExact(date, "MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out FechaVencimiento);
            if (FechaVencimiento < DateTime.Now)
            {
                return false;
            }
            return true;
        }
    }
}
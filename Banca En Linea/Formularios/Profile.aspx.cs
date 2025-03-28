using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Banca_En_Linea.Modelos;
using System.Data.SqlClient;
using Banca_En_Linea.Data;

namespace Banca_En_Linea
{
    public partial class _Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosCliente();
            }
        }
        private void CargarDatosCliente()
        {
            long cedula = 12345678; // Aquí deberías obtener la cédula del usuario autenticado

            using (var context = new Easy_Pay_Entities())
            {
                var cedulaParameter = new SqlParameter("@CEDULA_CLIENTE", cedula);

                var resultado = context.Database.SqlQuery<MProfile>(
                    "EXEC USP_CLIENTE_CUENTA_DATOS_SALDOS @CEDULA_CLIENTE",
                    cedulaParameter
                ).FirstOrDefault();

                if (resultado != null)
                {
                    lblNombreCompleto.Text = resultado.NombreCompleto;
                    lblNombreUsuario.Text = resultado.NombreUsuario;
                    lblDireccion.Text = resultado.Direccion;
                    lblNumeroCuenta.Text = resultado.NumeroDeCuenta;
                    lblSaldo.Text = resultado.Saldo.ToString("C"); // Formato moneda
                    imgFoto.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(resultado.Foto);
                }
                else
                {
                    lblMensaje.Text = "No se encontraron datos.";
                }
            }
        }
    }
}
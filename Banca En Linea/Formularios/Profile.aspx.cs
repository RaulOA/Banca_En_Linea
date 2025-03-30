using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Banca_En_Linea.Modelos;
using System.Data.SqlClient;
using Banca_En_Linea.Data;
using System.Data;

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

            long cedula = ObtenerCedulaUsuario();

            using (var context = new Easy_Pay_Entities())
            {
                var cedulaParameter = new SqlParameter("@CEDULA_CLIENTE", cedula);
                    
                context.Database.Connection.Open();

                try
                {
                    // 3. Ejecutar el comando
                    var command = context.Database.Connection.CreateCommand();
                    command.CommandText = "USP_CLIENTE_CUENTA_DATOS_SALDOS";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@CEDULA_CLIENTE", cedula));

                    // 4. Leer el primer resultset (datos del cliente)
                    var reader = command.ExecuteReader();

                    // 5. Procesar primer resultset
                    if (reader.Read())  
                    {

                        // Asignar a controles
                        lblNombreCompleto.Text = reader["NombreCompleto"].ToString();
                        lblNombreUsuario.Text = reader["NombreUsuario"].ToString();
                        lblDireccion.Text = reader["Direccion"].ToString();
                        lblNumeroCuenta.Text = reader["NumeroDeCuenta"].ToString();   // CUE.NumeroDeCuenta
                        lblSaldo.Text = Convert.ToDecimal(reader["Saldo"]).ToString("C");
                        imgFoto.ImageUrl = reader.IsDBNull(reader.GetOrdinal("Foto")) ? "img/default.jpg" : reader["Foto"].ToString();

                        // Mostrar resumen
                        //lblDepositos.Text = (reader["Depositos"] as decimal?).GetValueOrDefault(0).ToString("C");
                        //lblRetiros.Text = (reader["Retiros"] as decimal?).GetValueOrDefault(0).ToString("C");
                        //lblPayPal.Text = (reader["PayPal"] as decimal?).GetValueOrDefault(0).ToString("C");
                        //lblStripe.Text = (reader["Stripe"] as decimal?).GetValueOrDefault(0).ToString("C");
                        //lblTarjetaCredito.Text = (reader["TarjetaCredito"] as decimal?).GetValueOrDefault(0).ToString("C");
                        //lblTransferenciasBancarias.Text = (reader["TransferenciasBancarias"] as decimal?).GetValueOrDefault(0).ToString("C");
                        //lblPagosCartera.Text = (reader["PagosCartera"] as decimal?).GetValueOrDefault(0).ToString("C");
                        //lblReembolsos.Text = (reader["Reembolsos"] as decimal?).GetValueOrDefault(0).ToString("C");

                        // Totales consolidados
                        lblTotalIngresos.Text = (reader["TotalIngresos"] as decimal?).GetValueOrDefault(0).ToString("C");
                        lblTotalEgresos.Text = (reader["TotalEgresos"] as decimal?).GetValueOrDefault(0).ToString("C");
                    }

                    // 6. Pasar al segundo resultset (movimientos)
                    reader.NextResult();

                    var movimientos = new List<MovimientoViewModel>();
                    while (reader.Read())
                    {
                        movimientos.Add(new MovimientoViewModel
                        {
                            TipoMovimiento = ObtenerDescripcionAmigable(reader["TipoMovimiento"].ToString()),
                            Monto = Convert.ToDecimal(reader["Monto"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"])
                        });
                    }

                    // Asignar al GridView
                    gvTransacciones.DataSource = movimientos;
                    gvTransacciones.DataBind();
                }
                finally
                {
                    // Cerrar conexión
                    context.Database.Connection.Close();
                }
            }
        }

        private long ObtenerCedulaUsuario()
        {
            // Implementa según tu sistema de autenticación
            // Ejemplo: return ((Usuario)Session["Usuario"]).Cedula;
            return 206780934; // Temporal para pruebas
        }

        private string ObtenerDescripcionAmigable(string tipoMovimiento)
        {
            switch (tipoMovimiento)
            {
                case "Depósito": return "Depósito";
                case "Retiro": return "Retiro";
                case "Transferencia": return "Transferencia a otra cuenta";
                case "PayPal": return "Pago con PayPal";
                case "Stripe": return "Pago con tarjeta (Stripe)";
                case "TarjetaCredito": return "Pago con tarjeta de crédito";
                case "TransferenciaBancaria": return "Transferencia bancaria";
                case "PagoCartera": return "Pago de cartera";
                case "Reembolso": return "Reembolso";
                default: return tipoMovimiento;
            }
        }   
    }
}
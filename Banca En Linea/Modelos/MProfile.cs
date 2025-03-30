using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Banca_En_Linea.Modelos
{
    public class MProfile
    {
        public long Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string NombreUsuario { get; set; }
        public string Foto { get; set; } 
        public string Direccion { get; set; }
        public string NumeroDeCuenta { get; set; }
        public decimal Saldo { get; set; }
        public decimal Depositos { get; set; }
        public decimal Retiros { get; set; }
        public decimal Transferencias { get; set; }
        public decimal PayPal { get; set; }
        public decimal Stripe { get; set; }
        public decimal TarjetaCredito { get; set; }
        public decimal TransferenciasBancarias { get; set; }
        public decimal PagosCartera { get; set; }
        public decimal Reembolsos { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }   

    }

    public class MovimientoViewModel
    {
        public int ID { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string TipoTransaccion { get; set; }
    }
}
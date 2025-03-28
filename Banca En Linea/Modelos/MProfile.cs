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
        public byte[] Foto { get; set; } // Si la foto está almacenada como varbinary en SQL Server
        public string Direccion { get; set; }
        public string NumeroDeCuenta { get; set; }
        public decimal Saldo { get; set; }
        public decimal PayPal { get; set; }
        public decimal Stripe { get; set; }
        public decimal CreditCard { get; set; }
        public decimal Bank { get; set; }
        public decimal Wallet { get; set; }
        public decimal Refund { get; set; }


    }
}
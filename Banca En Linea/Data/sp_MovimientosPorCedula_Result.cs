//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Banca_En_Linea.Data
{
    using System;
    
    public partial class sp_MovimientosPorCedula_Result
    {
        public int ID { get; set; }
        public int CuentaID { get; set; }
        public int CatalogoMovimientosID { get; set; }
        public System.DateTime FechaMovimiento { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
    }
}

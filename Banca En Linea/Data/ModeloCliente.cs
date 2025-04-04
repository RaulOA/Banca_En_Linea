using System;

public class DatosCliente
{
    // Datos Personales
    public long Cedula { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string NombreUsuario { get; set; }
    public string Correo { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }

    // Tarjetas
    public string NumeroTarjeta { get; set; }
    public int tarjetaCVV { get; set; }
    public DateTime FechaVencimientoTarjeta { get; set; }

    // Cuentas
    public decimal cuentaSaldo { get; set; }
    public string TipoCuenta { get; set; }
    public string NumeroDeCuenta { get; set; }
    public int MonedaID { get; set; }

    // Movimientos
    public decimal MovimientosMonto { get; set; }
    public DateTime FechaMovimiento { get; set; }
    public int CatalogoMovimientoID { get; set; }
    public int CuantaMoviendoID { get; set; }
}

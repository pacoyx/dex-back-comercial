public class ResponseWgmainDto
{
    public int Id { get; set; }
    public string SerieGuia { get; set; } = "";
    public string NumeroGuia { get; set; } = "";
    public DateTime FechaOperacion { get; set; }
    public DateTime FechaHoraEntrega { get; set; }
    public string MensajeAlertas { get; set; } = "";
    public string Observaciones { get; set; } = "";
    public TipoPago TipoPago { get; set; }
    public string DescripcionPago { get; set; } = "";
    public TipoRecepcion TipoRecepcion { get; set; }
    public string DireccionContacto { get; set; } = "";
    public string TelefonoContacto { get; set; } = "";
    public decimal Total { get; set; }
    public decimal Acuenta { get; set; }
    public decimal Saldo { get; set; }   
}
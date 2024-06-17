public class CreateCashBoxDetailDto
{
    public string TipoComprobante { get; set; } = "";
    public string SerieComprobante { get; set; } = "";
    public string NumComprobante { get; set; } = "";
    public DateTime FechaComprobante { get; set; }
    public decimal Importe { get; set; }
    public decimal Adelanto { get; set; }
    public string TipoPago { get; set; } = "";
    public string DescripcionPago { get; set; } = "";
    public string Observaciones { get; set; } = "";
    public string EstadoRegistro { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public int CompanyId { get; set; }
    public int CustomerId { get; set; }
    public int CashBoxMainId { get; set; }
}

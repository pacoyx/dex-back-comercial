public class CashBoxDetail
{
    public int Id { get; set; }    
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
    public string EstadoLogico { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CompanyId { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int CashBoxMainId { get; set; }
    public CashBoxMain? CashBoxMain { get; set; }

}

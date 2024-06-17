public class PriceListDetail
{
    public int Id { get; set; }
    public decimal Precio { get; set; }
    public string EstadoRegistro { get; set; } = "";
    public string EstadoLogico { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CompanyId { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int PriceListMainId { get; set; }
    public PriceListMain? PriceListMain { get; set; }
}
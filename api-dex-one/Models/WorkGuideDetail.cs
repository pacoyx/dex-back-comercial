public class WorkGuideDetail
{
    public int Id { get; set; }
    public int Cant { get; set; }
    public decimal Precio { get; set; }
    public decimal Total { get; set; }
    public string Observaciones { get; set; } = "";
    public string TipoLavado { get; set; } = "";
    public string Ubicacion { get; set; } = "";
    public string EstadoTrabajo { get; set; } = "";
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int WorkGuideMainId { get; set; }
    public WorkGuideMain? WorkGuideMain { get; set; }
    public string EstadoRegistro { get; set; } = "";
    public string EstadoLogico { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CompanyId { get; set; }
}

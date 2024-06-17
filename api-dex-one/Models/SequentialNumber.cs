public class SequentialNumber
{
    public int Id { get; set; }
    public string CodSucursal { get; set; } = "";
    public string TipoDoc { get; set; } = "";
    public string SerieDoc { get; set; } = "";
    public int NumDoc { get; set; }
    public string EstadoRegistro { get; set; } = "";
    public string EstadoLogico { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CompanyId { get; set; }
}
public class UpdateSequentialNumberDto
{
    public int Id { get; set; }
    public string CodSucursal { get; set; } = "";
    public string TipoDoc { get; set; } = "";
    public string SerieDoc { get; set; } = "";
    public int NumDoc { get; set; }
    public string EstadoRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public int CompanyId { get; set; }
}
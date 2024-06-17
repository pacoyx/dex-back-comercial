public class CategoryProd
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = "";
    public string EstadoRegistro { get; set; } = "";
    public string EstadoLogico { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CompanyId { get; set; }
}
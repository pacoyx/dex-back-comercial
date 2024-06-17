public class Customer
{
    public int Id { get; set; }
    public string Nombres { get; set; } = "";
    public string DocumentoIdentidad { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string Observaciones { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaModificacion { get; set; }
    public string EstadoRegistro { get; set; } = "";
    public string EstadoLogico { get; set; } = "";
    public int CompanyId { get; set; }
}

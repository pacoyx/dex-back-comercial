public class CreateCustomerDto
{
    public string Nombres { get; set; } = "";
    public string DocumentoIdentidad { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string Observaciones { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public int CompanyId { get; set; }
}

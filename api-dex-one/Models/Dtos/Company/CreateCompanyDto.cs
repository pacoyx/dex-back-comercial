public class CreateCompanyDto
{
    public string TipoEmpresa { get; set; } = ""; // Persona Natural o Juridica
    public string TipoDocumentoPersona { get; set; } = "";
    public string RazonSocial { get; set; } = "";
    public string NumeroDocumentoRegistro { get; set; } = "";
    public string NombreComercio { get; set; } = "";
    public string RepresentanteLegal { get; set; } = "";
    public string NumeroDocumentoRepresentante { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string Email { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Celular { get; set; } = "";
    public string CodigoPostal { get; set; } = "";
    public string Ciudad { get; set; } = "";
    public string Pais { get; set; } = "";
    public string NombreContacto { get; set; } = "";
    public string TelefonoContacto { get; set; } = "";
    public string UrlWeb { get; set; } = "";
    public string UrlLogo { get; set; } = "";
    public int UserId { get; set; }

}
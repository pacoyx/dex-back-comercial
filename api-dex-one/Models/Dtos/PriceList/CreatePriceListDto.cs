public class CreatePriceListDto
{
    public string CodigoLista { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public int CompanyId { get; set; }
    public HashSet<PriceListDetailDto> Detalles { get; set; } = new HashSet<PriceListDetailDto>();
}


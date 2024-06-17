public class UpdatePriceListDto
{
    public int Id { get; set; }
    public string CodigoLista { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public string EstadoRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public HashSet<PriceListDetailDto> Detalles { get; set; } = new HashSet<PriceListDetailDto>();
}

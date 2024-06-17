public class CreateWorkGuideDetailDto
{
    public int Cant { get; set; }
    public decimal Precio { get; set; }
    public decimal Total { get; set; }
    public string Observaciones { get; set; } = "";
    public string TipoLavado { get; set; } = "";
    public string Ubicacion { get; set; } = "";
    public int ProductId { get; set; }
}

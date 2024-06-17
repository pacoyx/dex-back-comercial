public class UpdateBranchStoreDto
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string EstadoRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public int CompanyId { get; set; }
}
public class Product
{
    public int Id { get; set; }
    public string CodProd { get; set; } = "";
    public string Nombre { get; set; } = "";    
    public string UniMed { get; set; } = "";
    public string TipoProd { get; set; } = "";
    public string EstadoRegistro { get; set; } = "";
    public string EstadoLogico { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CompanyId { get; set; }
    public int CategoryId { get; set; }
    public CategoryProd? CategoryProd { get; set; }
}
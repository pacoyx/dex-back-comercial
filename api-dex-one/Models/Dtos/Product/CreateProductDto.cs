public class CreateProductDto
{    
    public string CodProd { get; set; } = "";
    public string Nombre { get; set; } = "";    
    public string UniMed { get; set; } = "";
    public string TipoProd { get; set; } = "";    
    public string UsuarioRegistro { get; set; } = "";        
    public int CompanyId { get; set; }
    public int CategoryId { get; set; }    
}
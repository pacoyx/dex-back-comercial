public class CreateExpenseBoxDto
{
    public string CategoryGasto { get; set; } = "";
    public string PersonalAutoriza { get; set; } = "";
    public DateTime FechaGasto { get; set; }
    public decimal Importe { get; set; }
    public string DetallesEgreso { get; set; } = ""; 
    public string UsuarioRegistro { get; set; } = "";
    public int CompanyId { get; set; }
}
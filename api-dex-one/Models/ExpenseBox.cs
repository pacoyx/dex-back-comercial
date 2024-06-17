public class ExpenseBox
{
    public int Id { get; set; }
    public string CategoryGasto { get; set; } = "";
    public string PersonalAutoriza { get; set; } = "";
    public DateTime FechaGasto { get; set; }
    public decimal Importe { get; set; }
    public string DetallesEgreso { get; set; } = "";
    public string EstadoRegistro { get; set; } = "";
    public string EstadoLogico { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CompanyId { get; set; }
}
public class UpdateExpenseBoxDto
{
    public int Id { get; set; }
    public string CategoryGasto { get; set; } = "";
    public string PersonalAutoriza { get; set; } = "";
    public DateTime FechaGasto { get; set; }
    public decimal Importe { get; set; }
    public string DetallesEgreso { get; set; } = "";
    public string EstadoRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
}
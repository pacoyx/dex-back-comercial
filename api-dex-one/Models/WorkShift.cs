public class WorkShift{
    public int Id { get; set; }
    public string Descripcion { get; set; } = "";
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraCierre { get; set; }
    public string Observaciones { get; set; } = "";
    public string EstadoRegistro { get; set; } = "";
    public string EstadoLogico { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public string UsuarioModificacion { get; set; } = "";
    public DateTime FechaRegistro { get; set; }
    public DateTime FechaModificacion { get; set; }
    public int CompanyId { get; set; }
}
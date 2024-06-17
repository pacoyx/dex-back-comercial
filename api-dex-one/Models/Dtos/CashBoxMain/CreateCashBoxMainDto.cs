public class CreateCashBoxMainDto
{
    public DateTime FechaCaja { get; set; }
    public DateTime FechaHoraApertura { get; set; }
    public DateTime FechaHoraCierre { get; set; }
    public string EstadoCaja { get; set; } = "";
    public decimal SaldoInicial { get; set; }
    public decimal SaldoFinal { get; set; }
    public decimal TotalIngreso { get; set; }
    public decimal TotalSalida { get; set; }
    public string Observaciones { get; set; } = "";
    public string UsuarioRegistro { get; set; } = "";
    public int CompanyId { get; set; }
    public int BranchStoreId { get; set; }
    public int WorkShiftId { get; set; }
    public int UserId { get; set; }
}
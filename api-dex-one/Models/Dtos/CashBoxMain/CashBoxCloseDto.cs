public class CashBoxCloseDto
{
    public int Id { get; set; }
    public DateTime FechaHoraCierre { get; set; }
    public decimal SaldoFinal { get; set; }
    public decimal TotalIngreso { get; set; }
    public decimal TotalSalida { get; set; }
    public string ObservacionesCierre { get; set; } = "";
    public string EstadoCaja { get; set; } = "";
}
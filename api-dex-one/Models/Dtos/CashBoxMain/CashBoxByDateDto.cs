public class CashBoxByDateDto{
    public int Id { get; set; }
    public DateTime FechaCaja { get; set; }
    public decimal SaldoInicial { get; set; }
    public decimal SaldoFinal { get; set; }
    public decimal TotalIngreso { get; set; }
    public decimal TotalSalida { get; set; }
    public string Observaciones { get; set; } = "";
    public string EstadoCaja { get; set; } = "";
    public string EstadoRegistro { get; set; } = "";
    public IEnumerable<CashBoxDetailByDateDto> CashBoxDetails { get; set; } = new List<CashBoxDetailByDateDto>();
}
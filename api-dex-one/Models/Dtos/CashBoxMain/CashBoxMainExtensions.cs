public static class CashBoxMainExtensions
{
    public static CashBoxMain AsCashBoxMain(this CreateCashBoxMainDto cashBoxMainDto)
    {
        return new CashBoxMain
        {
            FechaCaja = cashBoxMainDto.FechaCaja,
            FechaHoraApertura = cashBoxMainDto.FechaHoraApertura,
            FechaHoraCierre = cashBoxMainDto.FechaHoraCierre,
            EstadoCaja = cashBoxMainDto.EstadoCaja,
            SaldoInicial = cashBoxMainDto.SaldoInicial,
            SaldoFinal = cashBoxMainDto.SaldoFinal,
            TotalIngreso = cashBoxMainDto.TotalIngreso,
            TotalSalida = cashBoxMainDto.TotalSalida,
            Observaciones = cashBoxMainDto.Observaciones,
            UsuarioRegistro = cashBoxMainDto.UsuarioRegistro,
            UsuarioModificacion = "",
            FechaRegistro = DateTime.Now,
            FechaModificacion = DateTime.Now,
            BranchStoreId = cashBoxMainDto.BranchStoreId,
            WorkShiftId = cashBoxMainDto.WorkShiftId,
            CompanyId = cashBoxMainDto.CompanyId,
            UserId = cashBoxMainDto.UserId
        };
    }
}
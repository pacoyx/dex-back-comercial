public static class CashBoxDetailExtensions
{


    public static CashBoxDetail AsCashBoxDetail(this CreateCashBoxDetailDto cashBoxDetailDto)
    {
        return new CashBoxDetail
        {
            TipoComprobante = cashBoxDetailDto.TipoComprobante,
            SerieComprobante = cashBoxDetailDto.SerieComprobante,
            NumComprobante = cashBoxDetailDto.NumComprobante,
            FechaComprobante = cashBoxDetailDto.FechaComprobante,
            Importe = cashBoxDetailDto.Importe,
            Adelanto = cashBoxDetailDto.Adelanto,
            TipoPago = cashBoxDetailDto.TipoPago,
            DescripcionPago = cashBoxDetailDto.DescripcionPago,
            Observaciones = cashBoxDetailDto.Observaciones,
            UsuarioRegistro = cashBoxDetailDto.UsuarioRegistro,
            UsuarioModificacion = "",
            EstadoRegistro = "A",
            EstadoLogico = "A",
            FechaRegistro = DateTime.Now,
            FechaModificacion = DateTime.Now,
            CashBoxMainId = cashBoxDetailDto.CashBoxMainId,
            CompanyId = cashBoxDetailDto.CompanyId,
            CustomerId = cashBoxDetailDto.CustomerId
        };
    }
}
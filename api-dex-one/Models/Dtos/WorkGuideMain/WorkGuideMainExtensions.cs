public static class WorkGuideMainExtensions
{
    public static WorkGuideMain AsWorkGuideMain(this CreateWorkGuideMainDto wgmDto)
    {
        return new WorkGuideMain
        {
            SerieGuia = wgmDto.SerieGuia,
            NumeroGuia = wgmDto.NumeroGuia,
            FechaOperacion = wgmDto.FechaOperacion,
            FechaHoraEntrega = wgmDto.FechaHoraEntrega,
            MensajeAlertas = wgmDto.MensajeAlertas,
            Observaciones = wgmDto.Observaciones,
            TipoPago = wgmDto.TipoPago,
            DescripcionPago = wgmDto.DescripcionPago,
            TipoRecepcion = wgmDto.TipoRecepcion,
            DireccionContacto = wgmDto.DireccionContacto,
            TelefonoContacto = wgmDto.TelefonoContacto,
            Total = wgmDto.Total,
            Acuenta = wgmDto.Acuenta,
            Saldo = wgmDto.Saldo,
            CustomerId = wgmDto.CustomerId,
            UsuarioRegistro = wgmDto.UsuarioRegistro,
            CompanyId = wgmDto.CompanyId,
            EstadoRegistro = "A",
            EstadoLogico = "A",
            FechaRegistro = DateTime.Now,
            WorkGuideDetails = wgmDto.GuiaDetalles.Select(gd => new WorkGuideDetail
            {
                ProductId = gd.ProductId,
                Cant = gd.Cant,
                Precio = gd.Precio,
                Total = gd.Total,
                EstadoRegistro = "A",
                EstadoLogico = "A",
                UsuarioRegistro = wgmDto.UsuarioRegistro,
                UsuarioModificacion = wgmDto.UsuarioRegistro,
                FechaRegistro = DateTime.Now,
                FechaModificacion = DateTime.Now,
                CompanyId = wgmDto.CompanyId
            }).ToList()
        };
    }

    public static ResponseWgmainDto AsWorkGuideMain(this WorkGuideMain workGuideMain)
    {
        return new ResponseWgmainDto
        {
            Id = workGuideMain.Id,
            SerieGuia = workGuideMain.SerieGuia,
            NumeroGuia = workGuideMain.NumeroGuia,
            FechaOperacion = workGuideMain.FechaOperacion,
            FechaHoraEntrega = workGuideMain.FechaHoraEntrega,
            MensajeAlertas = workGuideMain.MensajeAlertas,
            Observaciones = workGuideMain.Observaciones,
            TipoPago = workGuideMain.TipoPago,
            DescripcionPago = workGuideMain.DescripcionPago,
            TipoRecepcion = workGuideMain.TipoRecepcion,
            DireccionContacto = workGuideMain.DireccionContacto,
            TelefonoContacto = workGuideMain.TelefonoContacto,
            Total = workGuideMain.Total,
            Acuenta = workGuideMain.Acuenta,
            Saldo = workGuideMain.Saldo,
        };
    }

}
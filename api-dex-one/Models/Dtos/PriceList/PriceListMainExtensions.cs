public static class PriceListMainExtensions
{
    public static PriceListMain AsPriceListMain(this CreatePriceListDto priceListMainDto)
    {
        return new PriceListMain
        {
            CodigoLista = priceListMainDto.CodigoLista,
            Descripcion = priceListMainDto.Descripcion,
            EstadoLogico = "A",
            EstadoRegistro = "A",
            UsuarioRegistro = priceListMainDto.UsuarioRegistro,
            UsuarioModificacion = priceListMainDto.UsuarioRegistro,
            FechaRegistro = DateTime.Now,
            FechaModificacion = DateTime.Now,
            CompanyId = priceListMainDto.CompanyId,
            Detalles = priceListMainDto.Detalles.Select(d => new PriceListDetail
            {
                Precio = d.Precio,
                ProductId = d.ProductId,
                EstadoLogico = "A",
                EstadoRegistro = "A",
                UsuarioRegistro = priceListMainDto.UsuarioRegistro,
                UsuarioModificacion = priceListMainDto.UsuarioRegistro,
                FechaRegistro = DateTime.Now,
                FechaModificacion = DateTime.Now,
                CompanyId = priceListMainDto.CompanyId,
            }).ToHashSet()
        };
    }

   
}
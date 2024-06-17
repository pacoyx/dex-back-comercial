public static class ProductExtensions
{
    public static SelectAllProductDto AsSelectAllProductDto(this Product product)
    {
        return new SelectAllProductDto
        {
            Id = product.Id,
            CodProd = product.CodProd,
            Nombre = product.Nombre,
            UniMed = product.UniMed,
            TipoProd = product.TipoProd,
            EstadoRegistro = product.EstadoRegistro,
            CategoryId = product.CategoryId,            
        };
    }
    public static Product AsProduct(this CreateProductDto product)
    {
        return new Product
        {            
            CodProd = product.CodProd,
            Nombre = product.Nombre,
            UniMed = product.UniMed,
            TipoProd = product.TipoProd,
            EstadoRegistro = "A",
            EstadoLogico = "A",
            UsuarioRegistro = product.UsuarioRegistro,
            UsuarioModificacion = product.UsuarioRegistro,
            FechaRegistro = DateTime.Now,
            FechaModificacion = DateTime.Now,
            CompanyId = product.CompanyId,
            CategoryId = product.CategoryId,            
        };
    }

    public static Product AsProduct(this UpdateProductDto UpdateProductDto)
    {
        return new Product
        {
            Id = UpdateProductDto.Id,
            CodProd = UpdateProductDto.CodProd,
            Nombre = UpdateProductDto.Nombre,
            UniMed = UpdateProductDto.UniMed,
            TipoProd = UpdateProductDto.TipoProd,
            EstadoRegistro = "A",            
            UsuarioModificacion = UpdateProductDto.UsuarioModificacion,            
            FechaModificacion = DateTime.Now,           
            CategoryId = UpdateProductDto.CategoryId,             
        };
    }
}
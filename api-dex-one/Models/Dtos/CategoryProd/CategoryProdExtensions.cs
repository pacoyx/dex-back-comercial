public static class CategoryProdExtensions
{
    public static SelectAllCategoryProdDto AsSelectAllCatProdDto(this CategoryProd categoryProd)
    {
        return new SelectAllCategoryProdDto
        {
            Id = categoryProd.Id,
            Descripcion = categoryProd.Descripcion,
            EstadoRegistro = categoryProd.EstadoRegistro,
        };
    }
    public static CategoryProd AsCategoryProd(this CreateCategoryProdDto createCategoryProdDto)
    {
        return new CategoryProd
        {
            Descripcion = createCategoryProdDto.Descripcion,
            EstadoRegistro = "A",
            EstadoLogico = "A",
            UsuarioRegistro = createCategoryProdDto.UsuarioRegistro,
            FechaRegistro = DateTime.Now,
            UsuarioModificacion = createCategoryProdDto.UsuarioRegistro,
            FechaModificacion = DateTime.Now,
            CompanyId = createCategoryProdDto.CompanyId
        };
    }

    public static CategoryProd AsCategoryProd(this UpdateCategoryProdDto UpdateCategoryProdDto)
    {
        return new CategoryProd
        {
            Id = UpdateCategoryProdDto.Id,
            Descripcion = UpdateCategoryProdDto.Descripcion,
            EstadoRegistro = UpdateCategoryProdDto.EstadoRegistro,
            UsuarioModificacion = UpdateCategoryProdDto.UsuarioModificacion,
            FechaModificacion = DateTime.Now,
        };
    }
}
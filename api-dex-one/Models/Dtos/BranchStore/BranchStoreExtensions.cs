public static class BranchStoreExtensions
{
       public static SelectAllBranchStoreDto AsSelectAllBranchStoreDto(this BranchStore branchStore)
    {
        return new SelectAllBranchStoreDto
        {
            Id = branchStore.Id,
            Descripcion = branchStore.Descripcion,
            Direccion = branchStore.Direccion,
            EstadoRegistro = branchStore.EstadoRegistro,            
        };
    }

    public static BranchStore AsBranchStore(this CreateBranchStoreDto branchStore)
    {
        return new BranchStore
        {
            Descripcion = branchStore.Descripcion,
            Direccion = branchStore.Direccion,
            EstadoRegistro = "A",
            EstadoLogico = "A",
            UsuarioRegistro = branchStore.UsuarioRegistro,
            UsuarioModificacion = "",
            FechaRegistro = DateTime.Now,
            FechaModificacion = DateTime.Now,
            CompanyId = branchStore.CompanyId
        };
    }

    public static BranchStore AsBranchStore(this UpdateBranchStoreDto updateBranchStoreDto)
    {
        return new BranchStore
        {
            Id = updateBranchStoreDto.Id,
            Descripcion = updateBranchStoreDto.Descripcion,
            Direccion = updateBranchStoreDto.Direccion,
            EstadoRegistro = updateBranchStoreDto.EstadoRegistro,
            UsuarioModificacion = updateBranchStoreDto.UsuarioModificacion,
            FechaModificacion = DateTime.Now,
            CompanyId = updateBranchStoreDto.CompanyId
        };
    }

}
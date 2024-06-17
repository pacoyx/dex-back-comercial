public static class SequentialNumbersExtensions
{

     public static SelectAllSequentialNumberDto AsSelectAllSequentialNumberDto(this SequentialNumber sequentialNumber)
    {
        return new SelectAllSequentialNumberDto
        {
            Id = sequentialNumber.Id,
            CodSucursal = sequentialNumber.CodSucursal,
            TipoDoc = sequentialNumber.TipoDoc,
            SerieDoc = sequentialNumber.SerieDoc,
            NumDoc = sequentialNumber.NumDoc,
            EstadoRegistro = sequentialNumber.EstadoRegistro,
        };
    }


    public static SequentialNumber AsSequentialNumber(this CreateSequentialNumberDto createSequentialNumberDto)
    {
        return new SequentialNumber
        {
            CodSucursal = createSequentialNumberDto.CodSucursal,
            TipoDoc = createSequentialNumberDto.TipoDoc,
            SerieDoc = createSequentialNumberDto.SerieDoc,
            NumDoc = createSequentialNumberDto.NumDoc,
            EstadoRegistro = "A",
            EstadoLogico = "A",
            UsuarioRegistro = createSequentialNumberDto.UsuarioRegistro,
            UsuarioModificacion = "",
            FechaRegistro = DateTime.Now,
            FechaModificacion = DateTime.Now,
            CompanyId = createSequentialNumberDto.CompanyId
        };
    }

}
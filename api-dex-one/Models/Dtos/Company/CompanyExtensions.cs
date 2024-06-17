public static class CompanyExtensions
{
    public static SelectAllDto AsDtoAll(this Company company)
    {
        return new SelectAllDto
        {
            Id = company.Id,
            TipoEmpresa = company.TipoEmpresa,
            TipoDocumentoPersona = company.TipoDocumentoPersona,
            RazonSocial = company.RazonSocial,
            NumeroDocumentoRegistro = company.NumeroDocumentoRegistro,
            NombreComercio = company.NombreComercio,
            RepresentanteLegal = company.RepresentanteLegal,
            NumeroDocumentoRepresentante = company.NumeroDocumentoRepresentante,
            Direccion = company.Direccion,
            Email = company.Email,
            Telefono = company.Telefono,
            Celular = company.Celular,
            CodigoPostal = company.CodigoPostal,
            Ciudad = company.Ciudad,
            Pais = company.Pais,
            NombreContacto = company.NombreContacto,
            TelefonoContacto = company.TelefonoContacto,
            UrlWeb = company.UrlWeb,
            UrlLogo = company.UrlLogo,
            EstadoRegistro = company.EstadoRegistro,
            Observaciones = company.Observaciones,

        };
    }

    public static Company AsCompany(this CreateCompanyDto createCompanyDto)
    {
        return new Company
        {
            TipoEmpresa = createCompanyDto.TipoEmpresa,
            TipoDocumentoPersona = createCompanyDto.TipoDocumentoPersona,
            RazonSocial = createCompanyDto.RazonSocial,
            NumeroDocumentoRegistro = createCompanyDto.NumeroDocumentoRegistro,
            NombreComercio = createCompanyDto.NombreComercio,
            RepresentanteLegal = createCompanyDto.RepresentanteLegal,
            NumeroDocumentoRepresentante = createCompanyDto.NumeroDocumentoRepresentante,
            Direccion = createCompanyDto.Direccion,
            Email = createCompanyDto.Email,
            Telefono = createCompanyDto.Telefono,
            Celular = createCompanyDto.Celular,
            CodigoPostal = createCompanyDto.CodigoPostal,
            Ciudad = createCompanyDto.Ciudad,
            Pais = createCompanyDto.Pais,
            NombreContacto = createCompanyDto.NombreContacto,
            TelefonoContacto = createCompanyDto.TelefonoContacto,
            UrlWeb = createCompanyDto.UrlWeb,
            UrlLogo = createCompanyDto.UrlLogo,
            Observaciones = "",
            EstadoRegistro = "A",
            EstadoLogico = "A",
            UsuarioRegistro = "admin",
            FechaRegistro = DateTime.Now,
            UsuarioModificacion = "admin",
            FechaModificacion = DateTime.Now,
            UserId = createCompanyDto.UserId

        };
    }

    // public static Company AsCompany(this UpdateCompanyDto updateCompanyDto)
    // {
    //     return new Company
    //     {
    //         Id = updateCompanyDto.Id,
    //         TipoEmpresa = updateCompanyDto.TipoEmpresa,
    //         TipoDocumentoPersona = updateCompanyDto.TipoDocumentoPersona,
    //         RazonSocial = updateCompanyDto.RazonSocial,
    //         NumeroDocumentoRegistro = updateCompanyDto.NumeroDocumentoRegistro,
    //         NombreComercio = updateCompanyDto.NombreComercio,
    //         RepresentanteLegal = updateCompanyDto.RepresentanteLegal,
    //         NumeroDocumentoRepresentante = updateCompanyDto.NumeroDocumentoRepresentante,
    //         Direccion = updateCompanyDto.Direccion,
    //         Email = updateCompanyDto.Email,
    //         Telefono = updateCompanyDto.Telefono,
    //         Celular = updateCompanyDto.Celular,
    //         CodigoPostal = updateCompanyDto.CodigoPostal,
    //         Ciudad = updateCompanyDto.Ciudad,
    //         Pais = updateCompanyDto.Pais,
    //         NombreContacto = updateCompanyDto.NombreContacto,
    //         TelefonoContacto = updateCompanyDto.TelefonoContacto,
    //         UrlWeb = updateCompanyDto.UrlWeb,
    //         UrlLogo = updateCompanyDto.UrlLogo,
    //         EstadoLogico = "A",
    //         UsuarioRegistro = updateCompanyDto.UsuarioRegistro,
    //         Observaciones = updateCompanyDto.Observaciones,
    //         EstadoRegistro = updateCompanyDto.EstadoRegistro,            
    //         UsuarioModificacion = updateCompanyDto.UsuarioModificacion,
    //         FechaModificacion = DateTime.Now,
    //     };
    // }
}
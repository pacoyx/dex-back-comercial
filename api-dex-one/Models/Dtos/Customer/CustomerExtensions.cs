public static class CustomerExtensions
{

    public static SelectAllCustomerDto AsSelectAllCustomerDto(this Customer customer)
    {
        return new SelectAllCustomerDto
        {
            Id = customer.Id,
            Nombres = customer.Nombres,
            DocumentoIdentidad = customer.DocumentoIdentidad,
            Telefono = customer.Telefono,
            Direccion = customer.Direccion,
            Observaciones = customer.Observaciones,
            EstadoRegistro = customer.EstadoRegistro,
        };
    }

    public static Customer AsCustomer(this CreateCustomerDto createCustomerDto)
    {
        return new Customer
        {
            Nombres = createCustomerDto.Nombres,
            DocumentoIdentidad = createCustomerDto.DocumentoIdentidad,
            Telefono = createCustomerDto.Telefono,
            Direccion = createCustomerDto.Direccion,
            Observaciones = createCustomerDto.Observaciones,
            UsuarioRegistro = createCustomerDto.UsuarioRegistro,
            FechaRegistro = DateTime.Now,
            FechaModificacion = DateTime.Now,
            EstadoRegistro = "A",
            EstadoLogico = "A",
            CompanyId = createCustomerDto.CompanyId
        };
    }

    public static Customer AsCustomer(this UpdateCustomerDto updateCustomerDto)
    {
        return new Customer
        {
            Id = updateCustomerDto.Id,
            Nombres = updateCustomerDto.Nombres,
            DocumentoIdentidad = updateCustomerDto.DocumentoIdentidad,
            Telefono = updateCustomerDto.Telefono,
            Direccion = updateCustomerDto.Direccion,
            Observaciones = updateCustomerDto.Observaciones,
            UsuarioModificacion = updateCustomerDto.UsuarioModificacion,
            FechaModificacion = DateTime.Now,
            EstadoRegistro = updateCustomerDto.EstadoRegistro,
            EstadoLogico = "A",
        };
    }
}
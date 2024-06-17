public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _unitOfWork.Customers.GetAll();
    }

    public async Task<Customer?> GetById(int id)
    {
        return await _unitOfWork.Customers.GetById(id);
    }

    public async Task Create(Customer customer)
    {
        await _unitOfWork.Customers.Create(customer);
    }

    public async Task<bool> Update(int customerId, UpdateCustomerDto customerDto)
    {
        var customerDb = await _unitOfWork.Customers.GetById(customerId);
        if (customerDb == null)
        {
            return false;
        }
        customerDb.Nombres = customerDto.Nombres;
        customerDb.DocumentoIdentidad = customerDto.DocumentoIdentidad;
        customerDb.Telefono = customerDto.Telefono;
        customerDb.Direccion = customerDto.Direccion;
        customerDb.Observaciones = customerDto.Observaciones;
        customerDb.UsuarioModificacion = customerDto.UsuarioModificacion;
        customerDb.FechaModificacion = DateTime.Now;
        customerDb.EstadoRegistro = customerDto.EstadoRegistro;
        
        _unitOfWork.Customers.Update(customerDb);
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var customer = await _unitOfWork.Customers.GetById(id);
        if (customer == null)
        {
            return false;
        }
        _unitOfWork.Customers.Delete(customer);
        return true;
    }

}
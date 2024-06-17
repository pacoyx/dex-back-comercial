public class CompanyService : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppLogger<CompanyService> _logger;

    public CompanyService(IUnitOfWork unitOfWork, IAppLogger<CompanyService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IEnumerable<Company>> GetAll()
    {
        return await _unitOfWork.Companies.GetAll();
    }

    public async Task<Company?> GetById(int companyId)
    {
        return await _unitOfWork.Companies.GetById(companyId);
    }

    public async Task Create(Company company)
    {
        await _unitOfWork.Companies.Create(company);
        _unitOfWork.Complete();
    }

    public async Task<bool> Update(int companyId, UpdateCompanyDto companyDto)
    {
        var companyDb = await _unitOfWork.Companies.GetById(companyId);
        if (companyDb == null)
        {
            return false;
        }

        companyDb.TipoEmpresa = companyDto.TipoEmpresa;
        companyDb.TipoDocumentoPersona = companyDto.TipoDocumentoPersona;
        companyDb.RazonSocial = companyDto.RazonSocial;
        companyDb.NumeroDocumentoRegistro = companyDto.NumeroDocumentoRegistro;
        companyDb.NombreComercio = companyDto.NombreComercio;
        companyDb.RepresentanteLegal = companyDto.RepresentanteLegal;
        companyDb.NumeroDocumentoRepresentante = companyDto.NumeroDocumentoRepresentante;        
        companyDb.Direccion = companyDto.Direccion;
        companyDb.Email = companyDto.Email;
        companyDb.Telefono = companyDto.Telefono;
        companyDb.Celular = companyDto.Celular;
        companyDb.CodigoPostal = companyDto.CodigoPostal;
        companyDb.Ciudad = companyDto.Ciudad;
        companyDb.Pais = companyDto.Pais;
        companyDb.NombreContacto = companyDto.NombreContacto;
        companyDb.TelefonoContacto = companyDto.TelefonoContacto;
        companyDb.UrlWeb = companyDto.UrlWeb;
        companyDb.UrlLogo = companyDto.UrlLogo;
        companyDb.EstadoRegistro = companyDto.EstadoRegistro;
        companyDb.UsuarioModificacion = companyDto.UsuarioModificacion;
        companyDb.FechaModificacion = DateTime.Now;
        companyDb.Observaciones = companyDto.Observaciones;

        _unitOfWork.Companies.Update(companyDb);
        _unitOfWork.Complete();
        return true;
    }

    public async Task<bool> Delete(int companyId)
    {
        var company = await _unitOfWork.Companies.GetById(companyId);
        if (company == null)
        {
            return false;
        }
        _unitOfWork.Companies.Delete(company);
        _unitOfWork.Complete();
        return true;
    }
}


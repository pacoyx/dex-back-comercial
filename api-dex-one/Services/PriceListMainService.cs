public class PriceListMainService : IPriceListMainService
{
    private readonly IUnitOfWork _unitOfWork;

    public PriceListMainService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PriceListMain>> GetAll()
    {
        return await _unitOfWork.PriceListMains.GetAll();
    }

    public async Task<PriceListMain?> GetById(int id)
    {
        return await _unitOfWork.PriceListMains.GetById(id);
    }

    public async Task Create(PriceListMain priceListMain)
    {
        await _unitOfWork.PriceListMains.Create(priceListMain);
        _unitOfWork.Complete();
    }

    public async Task<bool> Update(int priceListMainId, UpdatePriceListDto priceListMainDto)
    {
        var priceListMainDb = await _unitOfWork.PriceListMains.GetById(priceListMainId);
        if (priceListMainDb == null)
        {
            return false;
        }

        priceListMainDb.CodigoLista = priceListMainDto.CodigoLista;
        priceListMainDb.Descripcion = priceListMainDto.Descripcion;
        priceListMainDb.EstadoRegistro = priceListMainDto.EstadoRegistro;
        priceListMainDb.UsuarioModificacion = priceListMainDto.UsuarioModificacion;
        priceListMainDb.FechaModificacion = DateTime.Now;

        foreach (var item in priceListMainDb.Detalles)
        {
            item.Precio = priceListMainDto.Detalles.FirstOrDefault(d => d.Id == item.Id)?.Precio ?? item.Precio;
        }

        var newDetails = priceListMainDto.Detalles.Where(d => d.Id == 0).Select(d => new PriceListDetail
        {
            Precio = d.Precio,
            ProductId = d.ProductId,
            EstadoLogico = "A",
            EstadoRegistro = "A",
            UsuarioRegistro = priceListMainDb.UsuarioRegistro,
            UsuarioModificacion = priceListMainDto.UsuarioModificacion,
            FechaRegistro = DateTime.Now,
            FechaModificacion = DateTime.Now,
            CompanyId = priceListMainDb.CompanyId
        }).ToHashSet();

        priceListMainDb.Detalles = priceListMainDb.Detalles.Union(newDetails).ToHashSet();


        var listaFaltantes = priceListMainDb.Detalles.Where(d => !priceListMainDto.Detalles.Select(x => x.Id).Contains(d.Id)).ToList();
        foreach (var item in listaFaltantes)
        {
            _unitOfWork.PriceListPlus.DeleteDetail(item);
        }

        // foreach (var item in priceListMainDb.Detalles)
        // {
        //     _unitOfWork.PriceListMains.DeleteDetail(item);
        // }

        // priceListMainDb.Detalles = priceListMainDto.Detalles.Select(d => new PriceListDetail
        // {
        //     Precio = d.Precio,
        //     ProductId = d.ProductId,
        //     EstadoLogico = "A",
        //     EstadoRegistro = "A",
        //     UsuarioRegistro = priceListMainDb.UsuarioRegistro,
        //     UsuarioModificacion = priceListMainDto.UsuarioModificacion,
        //     FechaRegistro = DateTime.Now,
        //     FechaModificacion = DateTime.Now,
        //     CompanyId = priceListMainDb.CompanyId
        // }).ToHashSet();




        _unitOfWork.PriceListMains.Update(priceListMainDb);
        _unitOfWork.Complete();
        return true;
    }

    public async Task<bool> Delete(int priceListMainId)
    {
        var priceListMainToDelete = await _unitOfWork.PriceListMains.GetById(priceListMainId);
        if (priceListMainToDelete == null)
        {
            return false;
        }
        _unitOfWork.PriceListMains.Delete(priceListMainToDelete);
        _unitOfWork.Complete();
        return true;
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CashBoxMainRepository : ICashBoxMainRepository
{
    private readonly MyDbContext _context;

    public CashBoxMainRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CashBoxMain>> GetCashBoxMains()
    {
        return await _context.CashBoxMains.ToListAsync();
    }

    public async Task<CashBoxMain?> GetCashBoxMain(int id)
    {
        return await _context.CashBoxMains.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<CashBoxMain> AddCashBoxMain(CashBoxMain cashBoxMain)
    {
        await _context.CashBoxMains.AddAsync(cashBoxMain);
        return cashBoxMain;
    }

    public void UpdateCashBoxMain(CashBoxMain cashBoxMain)
    {
        _context.CashBoxMains.Update(cashBoxMain);
    }

    public void DeleteCashBoxMain(CashBoxMain cashBoxMain)
    {
        _context.CashBoxMains.Remove(cashBoxMain);
    }

    public async Task<IEnumerable<CashBoxByDateDto>> GetCashBoxByDate(DateTime fecha, int companyId, int branchId, int userId)
    {
        var modelos = await _context.CashBoxMains
            .Include(m => m.CashBoxDetails)
                .ThenInclude(m => m.Customer)
            .Where(m => m.FechaCaja.Date == fecha.Date
            && m.BranchStoreId == branchId
            && m.CompanyId == companyId
            && m.UserId == userId)
             .Select(c => new CashBoxByDateDto
             {
                 Id = c.Id,
                 FechaCaja = c.FechaCaja,
                 SaldoInicial = c.SaldoInicial,
                 SaldoFinal = c.SaldoFinal,
                 TotalIngreso = c.TotalIngreso,
                 TotalSalida = c.TotalSalida,
                 Observaciones = c.Observaciones,
                 EstadoCaja = c.EstadoCaja,
                 EstadoRegistro = c.EstadoRegistro,
                 CashBoxDetails = c.CashBoxDetails.Select(d => new CashBoxDetailByDateDto
                 {
                     Id = d.Id,
                     TipoComprobante = d.TipoComprobante,
                     SerieComprobante = d.SerieComprobante,
                     NumComprobante = d.NumComprobante,
                     FechaComprobante = d.FechaComprobante,
                     Importe = d.Importe,
                     Adelanto = d.Adelanto,
                     TipoPago = d.TipoPago,
                     DescripcionPago = d.DescripcionPago,
                     Observaciones = d.Observaciones,
                     EstadoRegistro = d.EstadoRegistro,
                     Customer = new CustomerByDateDto
                     {
                         Nombre = d.Customer!.Nombres,
                         Telefono = d.Customer.Telefono,
                     }
                 })
             })
            .ToListAsync();

        return modelos;
    }

    public void CloseCashBox(CashBoxMain cashBoxMain)
    {
        _context.CashBoxMains.Update(cashBoxMain);
    }

}
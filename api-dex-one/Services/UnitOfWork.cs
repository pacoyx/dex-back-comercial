public class UnitOfWork : IUnitOfWork
{
    private readonly MyDbContext _context;
    public IRepository<BranchStore> BranchStores { get; private set; }
    public IRepository<Role> Roles { get; private set; }
    public IRepository<WorkShift> WorkShifts { get; private set; }
    public IRepository<SequentialNumber> SequentialNumbers { get; private set; }
    public IRepository<Company> Companies { get; private set; }
    public IRepository<CategoryProd> CategoryProds { get; private set; }
    public IRepository<Product> Products { get; private set; }
    public IRepository<ExpenseBox> ExpenseBoxes { get; private set; }
    public IRepository<Customer> Customers { get; private set; }
    public IRepository<User> Users { get; private set; }
    public IUserPlusRepository UsersPlus { get; private set; }
    public IRepository<PriceListMain> PriceListMains { get; private set; }
    public IPriceListPlusRepository PriceListPlus { get; private set; }

    public ICashBoxMainRepository CashBoxMains { get; private set; }
    public ICashBoxDetailRepository CashBoxDetails { get; private set; }
    public IWorkGuideMainRepository WorkGuideMains { get; private set; }



    public UnitOfWork(MyDbContext context)
    {
        _context = context;
        Roles = new RoleRepository(_context);
        BranchStores = new BranchStoreRepository(_context);
        WorkShifts = new WorkShiftRepository(_context);
        Companies = new CompanyRepository(_context);
        CategoryProds = new CategoryProdRepository(_context);
        Customers = new CustomerRepository(_context);
        Products = new ProductRepository(_context);
        Users = new UserRepository(_context);        
        UsersPlus = new UserPlusRepository(_context);
        PriceListMains = new PriceListRepository(_context);
        PriceListPlus = new PriceListPlusRepository(_context);

        ExpenseBoxes = new ExpenseBoxRepository(_context);
        SequentialNumbers = new SequentialNumberRepository(_context);
        CashBoxMains = new CashBoxMainRepository(_context);
        CashBoxDetails = new CashBoxDetailRepository(_context);
        WorkGuideMains = new WorkGuideMainRepository(_context);
    }

    public async void Complete()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
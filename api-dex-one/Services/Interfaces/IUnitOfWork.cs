
public interface IUnitOfWork : IDisposable
{
    ICashBoxMainRepository CashBoxMains { get; }
    ICashBoxDetailRepository CashBoxDetails { get; }
    IWorkGuideMainRepository WorkGuideMains { get; }
    
    IRepository<PriceListMain> PriceListMains { get; }
    IPriceListPlusRepository PriceListPlus { get; }
    IUserPlusRepository UsersPlus { get; }
    IRepository<User> Users { get; }
    IRepository<Role> Roles { get; }
    IRepository<Company> Companies { get; }
    IRepository<CategoryProd> CategoryProds { get; }
    IRepository<Product> Products { get; }
    IRepository<BranchStore> BranchStores { get; }
    IRepository<ExpenseBox> ExpenseBoxes { get; }
    IRepository<Customer> Customers { get; }
    IRepository<SequentialNumber> SequentialNumbers { get; }
    IRepository<WorkShift> WorkShifts { get; }
    void Complete();
}
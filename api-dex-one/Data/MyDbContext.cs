using Microsoft.EntityFrameworkCore;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
       : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CategoryProd> CategoryProds { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<BranchStore> BranchStores { get; set; }
    public DbSet<ExpenseBox> ExpenseBoxes { get; set; }
    public DbSet<PriceListMain> PriceListMains { get; set; }
    public DbSet<PriceListDetail> PriceListDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<SequentialNumber> SequentialNumbers { get; set; }
    public DbSet<CashBoxMain> CashBoxMains { get; set; }
    public DbSet<WorkShift> WorkShifts { get; set; }
    public DbSet<CashBoxDetail> CashBoxDetails { get; set; }
    public DbSet<WorkGuideMain> WorkGuideMains { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);
    }
}
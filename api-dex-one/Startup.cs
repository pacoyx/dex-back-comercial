using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

public static class Startup
{

    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration, ILogger logger)
    {
        logger.LogInformation("========Configuring services...");

        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        });

        services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
        });


        //services.AddDbContext<MyDbContext>(options => options.UseInMemoryDatabase("MyDatabase"));
        services.AddDbContext<MyDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("comercialDatabase"));
        });
        
        
        //IniciarData();

        services.AddHealthChecks();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRolService, RolService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICategoryProdService, CategoryProdService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IBranchStoreService, BranchStoreService>();
        services.AddScoped<IExpenseBoxService, ExpenseBoxService>();
        services.AddScoped<IPriceListMainService, PriceListMainService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ISequentialNumberService, SequentialNumberService>();
        services.AddScoped<ICashBoxMainService, CashBoxMainService>();
        services.AddScoped<ICashBoxDetailService, CashBoxDetailService>();
        services.AddScoped<IWorkGuideMainService, WorkGuideMainService>();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<ExceptionMiddleware>();
        app.UseMiddleware<JwtMiddleware>();


        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.UseHealthChecks("/health");

        // app.UseAuthentication();
        // app.UseAuthorization();


    }

    static void IniciarData()
    {
        // Configura las opciones del DbContext para usar una base de datos en memoria
        var options = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: "MyDatabase")
            .Options;

        // Crea una instancia del DbContext
        using (var context = new MyDbContext(options))
        {
            // Asegúrate de que la base de datos está creada
            context.Database.EnsureCreated();

            // Agrega datos iniciales
            context.Users.Add(new User { Id = 1, Name = "carlos", Email = "carlos@rimac.com", PasswordHash = "123", RoleNameShort = "Admin" });
            context.Users.Add(new User { Id = 2, Name = "javier", Email = "javier@rimac.com", PasswordHash = "123", RoleNameShort = "User" });
            context.SaveChanges();
        }
    }
}
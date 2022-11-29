using ALevelSample.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Shop;
using Shop.Data;
using Shop.Repositories;
using Shop.Repositories.Abstractions;
using Shop.Services;
using Shop.Services.Abstractons;

public class Program
{
    public static async Task Main(string[] args)
    {
        void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.AddScoped<IDbContextWrapper<ApplicationDBContext>,
                DbContextWrapper<ApplicationDBContext>>()
                .AddDbContextFactory<ApplicationDBContext>(
                opts => opts.UseNpgsql(connectionString))
                .AddLogging(configure => configure.AddConsole())
                .AddTransient<ISupplierRepository, SupplierRepository>()
                .AddTransient<ISupplierService, SupplierService>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IShipperRepository, ShipperRepository>()
                .AddTransient<IShipperService, ShipperService>()
                .AddTransient<ICustomerRepository, CustomerRepository>()
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<IPaymentRepository, PaymentRepository>()
                .AddTransient<IPaymentService, PaymentService>()
                .AddTransient<IOrderRepository, OrderRepository>()
                .AddTransient<IOrderService, OrderService>()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductService, ProductService>()
                .AddTransient<App>();
        }

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection, configuration);
        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();
        await app!.Run();
    }
}
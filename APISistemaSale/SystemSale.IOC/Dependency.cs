using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SystemSale.DAL.DBContext;
using SystemSale.DAL.Repository;
using SystemSale.DAL.Repository.Contract;
using SystemSale.Utility;

namespace SystemSale.IOC
{
    public static class Dependency
    {
        public static void InjectDependencys(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbsaleContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("connectionString"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISaleRepository, SaleRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProdutoApi.Infraestructure.Context;

namespace ProdutoApi.Infraestructure.Extensions
{
    public static class DataBaseContextExtension
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DataBase")));

            return services;
        }
    }
}

using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.UseCases.Handlers;

namespace ProdutoApi.Infraestructure.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddTransient<TaxRepository>();
            services.AddTransient<MeasurementsRepository>();
            services.AddTransient<ProductRepository>();
            services.AddTransient<ProductTypeRepository>();
            services.AddTransient<CreateTaxCommandHandler>();
            services.AddTransient<CreateMeasurementCommandHandler>();
            services.AddTransient<CreateProductTypeCommandHandler>();
            services.AddTransient<CreateProductCommandHandler>();

            return services;
        }
    }
}

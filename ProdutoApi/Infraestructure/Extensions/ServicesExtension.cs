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
            services.AddTransient<UpdateTaxCommandHandler>();
            services.AddTransient<UpdateMeasurementCommandHandler>();
            services.AddTransient<UpdateProductCommandHandler>();
            services.AddTransient<UpdateProductTypeCommandHandler>();
            services.AddTransient<DeleteTaxCommandHandler>();
            services.AddTransient<DeleteMeasurementCommandHandler>();
            services.AddTransient<DeleteProductCommandHandler>();
            services.AddTransient<DeleteProductTypeCommandHandler>();
            services.AddTransient<GetSingleTaxCommandHandler>();
            services.AddTransient<GetSingleMeasurementCommandHandler>();
            services.AddTransient<GetSingleProductCommandHandler>();
            services.AddTransient<GetSingleProductTypeCommandHandler>();
            services.AddTransient<GetAllTaxCommandHandler>();
            services.AddTransient<GetAllProductCommandHandler>();
            services.AddTransient<GetAllProductTypeCommandHandler>();
            services.AddTransient<GetAllMeasurementCommandHandler>();
            services.AddTransient<GetAllProductsWithStockCommandHandler>();

            return services;
        }
    }
}

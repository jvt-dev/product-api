using Microsoft.EntityFrameworkCore;
using ProdutoApi.Domain.Entities;

namespace ProdutoApi.Infraestructure.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }
        public DbSet<TaxEntity> Tax { get; set; }
        public DbSet<MeasurementsEntity> Measurements { get; set; }
        public DbSet<ProductTypeEntity> ProductType { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
    }
}

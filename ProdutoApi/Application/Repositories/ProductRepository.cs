using ProdutoApi.Domain.Entities;
using ProdutoApi.Infraestructure.Context;

namespace ProdutoApi.Application.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}

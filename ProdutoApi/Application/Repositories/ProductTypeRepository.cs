using ProdutoApi.Domain.Entities;
using ProdutoApi.Infraestructure.Context;

namespace ProdutoApi.Application.Repositories
{
    public class ProductTypeRepository : GenericRepository<ProductTypeEntity>
    {
        public ProductTypeRepository(ProductContext context) : base(context)
        {
        }
    }
}

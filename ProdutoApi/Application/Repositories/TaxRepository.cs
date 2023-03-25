using ProdutoApi.Domain.Entities;
using ProdutoApi.Infraestructure.Context;

namespace ProdutoApi.Application.Repositories
{
    public class TaxRepository : GenericRepository<TaxEntity>
    {
        public TaxRepository(ProductContext context) : base(context)
        {
        }
    }
}

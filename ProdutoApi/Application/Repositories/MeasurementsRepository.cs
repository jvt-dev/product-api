using ProdutoApi.Domain.Entities;
using ProdutoApi.Infraestructure.Context;

namespace ProdutoApi.Application.Repositories
{
    public class MeasurementsRepository : GenericRepository<MeasurementsEntity>
    {
        public MeasurementsRepository(ProductContext context) : base(context)
        {
        }
    }
}

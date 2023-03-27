using Microsoft.EntityFrameworkCore;
using ProdutoApi.Domain.Entities;
using ProdutoApi.Infraestructure.Context;

namespace ProdutoApi.Application.Repositories
{
    public class ProductRepository : IGenericRepository<ProductEntity>
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task Add(ProductEntity entity)
        {
            await _context.Set<ProductEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity).Reference(r => r.ProductType).LoadAsync();
            await _context.Entry(entity.ProductType).Reference(r => r.Tax).LoadAsync();
            await _context.Entry(entity.ProductType).Reference(r => r.Measurements).LoadAsync();
        }

        public async Task Update(ProductEntity entity)
        {
            _context.Set<ProductEntity>().Update(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity).Reference(r => r.ProductType).LoadAsync();
            await _context.Entry(entity.ProductType).Reference(r => r.Tax).LoadAsync();
            await _context.Entry(entity.ProductType).Reference(r => r.Measurements).LoadAsync();
        }

        public async Task Delete(ProductEntity entity)
        {
            _context.Set<ProductEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductEntity?> GetEntityById(long id)
        {
            var entity = await _context.Set<ProductEntity>()
                .Include(i => i.ProductType)
                .Include(i => i.ProductType.Tax)
                .Include(i => i.ProductType.Measurements)
                .FirstOrDefaultAsync(p => p.Id.Equals(id));
            return entity;
        }

        public async Task<List<ProductEntity>> GetAll()
        {
            return await _context.Set<ProductEntity>()
                .Include(i => i.ProductType)
                .Include(i => i.ProductType.Tax)
                .Include(i => i.ProductType.Measurements)
                .ToListAsync();
        }
    }
}

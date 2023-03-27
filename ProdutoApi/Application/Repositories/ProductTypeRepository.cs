using Microsoft.EntityFrameworkCore;
using ProdutoApi.Domain.Entities;
using ProdutoApi.Infraestructure.Context;

namespace ProdutoApi.Application.Repositories
{
    public class ProductTypeRepository : IGenericRepository<ProductTypeEntity>
    {
        private readonly ProductContext _context;

        public ProductTypeRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task Add(ProductTypeEntity entity)
        {
            await _context.Set<ProductTypeEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity).Reference(r => r.Tax).LoadAsync();
            await _context.Entry(entity).Reference(r => r.Measurements).LoadAsync();
        }

        public async Task Update(ProductTypeEntity entity)
        {
            _context.Set<ProductTypeEntity>().Update(entity);
            await _context.SaveChangesAsync();
            await _context.Entry(entity).Reference(r => r.Tax).LoadAsync();
            await _context.Entry(entity).Reference(r => r.Measurements).LoadAsync();
        }

        public async Task Delete(ProductTypeEntity entity)
        {
            _context.Set<ProductTypeEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductTypeEntity?> GetEntityById(long id)
        {
            var entity = await _context.Set<ProductTypeEntity>()
                .Include(i => i.Measurements)
                .Include(i => i.Tax)
                .FirstOrDefaultAsync(p => p.Id.Equals(id));
            return entity;
        }

        public async Task<List<ProductTypeEntity>> GetAll()
        {
            return await _context.Set<ProductTypeEntity>().Include(i => i.Measurements).Include(i => i.Tax).ToListAsync();
        }
    }
}

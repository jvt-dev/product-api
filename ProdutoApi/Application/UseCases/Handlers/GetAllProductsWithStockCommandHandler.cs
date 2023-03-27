using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Domain.Entities;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class GetAllProductsWithStockCommandHandler : IHandler<GetAllProductsWithStockCommand>
    {
        private readonly ProductRepository _productRepository;

        public GetAllProductsWithStockCommandHandler(ProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<RequestResult> Handle(GetAllProductsWithStockCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var validEntities = new List<ProductEntity>();
                var entities = await _productRepository.GetAll();

                foreach(var entity in entities)
                {
                    if(entity.ValidateFinalPriceValue())
                    {
                        validEntities.Add(entity);
                    }
                }

                return requestResult.Ok(validEntities);
            }
            catch(Exception ex)
            {
                return requestResult.BadRequest(ex.Message);
            }
        }
    }
}

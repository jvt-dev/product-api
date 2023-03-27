using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class UpdateProductCommandHandler : IHandler<UpdateProductCommand>
    {
        private readonly ProductRepository _productRepository;

        public UpdateProductCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<RequestResult> Handle(UpdateProductCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var entity = await _productRepository.GetEntityById(command.Id);

                if (entity is null)
                {
                    return requestResult.BadRequest("Inform a valid id");
                }

                entity.UpdateQuantity(command.Quantity);

                await _productRepository.Update(entity);

                return requestResult.Ok(entity);
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

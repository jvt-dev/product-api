using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class DeleteProductCommandHandler : IHandler<DeleteCommand>
    {
        private readonly ProductRepository _productRepository;

        public DeleteProductCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<RequestResult> Handle(DeleteCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var entity = await _productRepository.GetEntityById(command.Id);

                if (entity is null)
                {
                    return requestResult.BadRequest("Inform a valid id");
                }

                await _productRepository.Delete(entity);

                return requestResult.Ok();
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

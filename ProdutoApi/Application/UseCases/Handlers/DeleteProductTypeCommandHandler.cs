using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class DeleteProductTypeCommandHandler : IHandler<DeleteCommand>
    {
        private readonly ProductTypeRepository _productTypeRepository;

        public DeleteProductTypeCommandHandler(ProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<RequestResult> Handle(DeleteCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var entity = await _productTypeRepository.GetEntityById(command.Id);

                if (entity is null)
                {
                    return requestResult.BadRequest("Inform a valid id");
                }

                await _productTypeRepository.Delete(entity);

                return requestResult.Ok();
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class GetSingleProductCommandHandler : IHandler<GetSingleCommand>
    {
        private readonly ProductRepository _productRepository;

        public GetSingleProductCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<RequestResult> Handle(GetSingleCommand command)
        {
            var requestResult = new RequestResult();

            var entity = await _productRepository.GetEntityById(command.Id);

            if (entity is null)
            {
                return requestResult.BadRequest("Inform a valid id");
            }

            return requestResult.Ok(entity);
        }
    }
}

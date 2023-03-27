using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.Repositories;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class GetAllProductCommandHandler : IHandler<GetAllCommand>
    {
        private readonly ProductRepository _productRepository;

        public GetAllProductCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<RequestResult> Handle(GetAllCommand command)
        {
            var requestResult = new RequestResult();
            var entities = await _productRepository.GetAll();

            return requestResult.Ok(entities);
        }
    }
}

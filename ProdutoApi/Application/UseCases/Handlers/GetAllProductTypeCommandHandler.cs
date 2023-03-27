using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.Repositories;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class GetAllProductTypeCommandHandler : IHandler<GetAllCommand>
    {
        private readonly ProductTypeRepository _productTypeRepository;

        public GetAllProductTypeCommandHandler(ProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<RequestResult> Handle(GetAllCommand command)
        {
            var requestResult = new RequestResult();
            var entities = await _productTypeRepository.GetAll();

            return requestResult.Ok(entities);
        }
    }
}

using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class GetSingleProductTypeCommandHandler : IHandler<GetSingleCommand>
    {
        private readonly ProductTypeRepository _productTypeRepository;

        public GetSingleProductTypeCommandHandler(ProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<RequestResult> Handle(GetSingleCommand command)
        {
            var requestResult = new RequestResult();

            var entity = await _productTypeRepository.GetEntityById(command.Id);

            if(entity is null)
            {
                return requestResult.BadRequest("Inform a valid id");
            }

            return requestResult.Ok(entity);
        }
    }
}

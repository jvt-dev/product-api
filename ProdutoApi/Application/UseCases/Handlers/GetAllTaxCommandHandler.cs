using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class GetAllTaxCommandHandler : IHandler<GetAllCommand>
    {
        private readonly TaxRepository _taxRepository;

        public GetAllTaxCommandHandler(TaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public async Task<RequestResult> Handle(GetAllCommand command)
        {
            var requestResult = new RequestResult();
            var entities = await _taxRepository.GetAll();

            return requestResult.Ok(entities);
        }
    }
}

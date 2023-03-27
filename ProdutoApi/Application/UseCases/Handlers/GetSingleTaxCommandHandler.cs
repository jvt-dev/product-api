using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class GetSingleTaxCommandHandler : IHandler<GetSingleCommand>
    {
        private readonly TaxRepository _taxRepository;

        public GetSingleTaxCommandHandler(TaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public async Task<RequestResult> Handle(GetSingleCommand command)
        {
            var requestResult = new RequestResult();

            var entity = await _taxRepository.GetEntityById(command.Id);

            if (entity is null)
            {
                return requestResult.BadRequest("Inform a valid id");
            }

            return requestResult.Ok(entity);
        }
    }
}

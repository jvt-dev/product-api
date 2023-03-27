using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class DeleteTaxCommandHandler : IHandler<DeleteCommand>
    {
        private readonly TaxRepository _taxRepository;

        public DeleteTaxCommandHandler(TaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public async Task<RequestResult> Handle(DeleteCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var entity = await _taxRepository.GetEntityById(command.Id);

                if (entity is null)
                {
                    return requestResult.BadRequest("Inform a valid id");
                }

                await _taxRepository.Delete(entity);

                return requestResult.Ok();
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

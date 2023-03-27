using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class UpdateTaxCommandHandler : IHandler<UpdateTaxCommand>
    {
        private readonly TaxRepository _taxRepository;

        public UpdateTaxCommandHandler(TaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        public async Task<RequestResult> Handle(UpdateTaxCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var entity = await _taxRepository.GetEntityById(command.Id);

                if (entity is null)
                {
                    return requestResult.BadRequest("Inform a valid id");
                }

                entity.UpdateValue(command.Value);

                if (!entity.IsValid)
                {
                    return requestResult.BadRequest("Inform a valid value");
                }

                await _taxRepository.Update(entity);

                return requestResult.Ok(entity);
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

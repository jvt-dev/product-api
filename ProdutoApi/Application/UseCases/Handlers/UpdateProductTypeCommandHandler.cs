using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class UpdateProductTypeCommandHandler : IHandler<UpdateProductTypeCommand>
    {
        private readonly ProductTypeRepository _productTypeRepository;

        public UpdateProductTypeCommandHandler(ProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public async Task<RequestResult> Handle(UpdateProductTypeCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var entity = await _productTypeRepository.GetEntityById(command.Id);

                if (entity is null)
                {
                    return requestResult.BadRequest("Inform a valid id");
                }

                entity.UpdatePrice(command.Price);

                if (!entity.IsValid)
                {
                    return requestResult.BadRequest("Inform a valid price");
                }

                await _productTypeRepository.Update(entity);

                return requestResult.Ok(entity);
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

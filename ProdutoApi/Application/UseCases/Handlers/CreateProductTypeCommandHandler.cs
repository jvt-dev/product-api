using AutoMapper;
using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Domain.Entities;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class CreateProductTypeCommandHandler : IHandler<CreateProductTypeCommand>
    {
        private readonly ProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public CreateProductTypeCommandHandler(ProductTypeRepository productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult> Handle(CreateProductTypeCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var productTypeEntity = _mapper.Map<ProductTypeEntity>(command);

                if (!productTypeEntity.IsValid)
                {
                    return requestResult.BadRequest("Inform a valid value");
                }

                await _productTypeRepository.Add(productTypeEntity);
                return requestResult.Ok(productTypeEntity);
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

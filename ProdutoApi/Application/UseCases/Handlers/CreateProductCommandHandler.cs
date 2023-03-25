using AutoMapper;
using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Domain.Entities;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class CreateProductCommandHandler : IHandler<CreateProductCommand>
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult> Handle(CreateProductCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var productEntity = _mapper.Map<ProductEntity>(command);

                if (!productEntity.IsValid)
                {
                    return requestResult.BadRequest("Inform a valid value");
                }

                await _productRepository.Add(productEntity);
                return requestResult.Ok(productEntity);
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

using AutoMapper;
using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Domain.Entities;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class CreateTaxCommandHandler : IHandler<CreateTaxCommand>
    {
        private readonly TaxRepository _taxRepository;
        private readonly IMapper _mapper;

        public CreateTaxCommandHandler(TaxRepository taxRepository, IMapper mapper)
        {
            _taxRepository = taxRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult> Handle(CreateTaxCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var taxEntity = _mapper.Map<TaxEntity>(command);

                if (!taxEntity.IsValid)
                {
                    return requestResult.BadRequest("Inform a valid tax value");
                }

                await _taxRepository.Add(taxEntity);
                return requestResult.Ok(taxEntity);
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

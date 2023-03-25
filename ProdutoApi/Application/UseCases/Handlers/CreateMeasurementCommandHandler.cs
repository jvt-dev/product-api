using AutoMapper;
using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Domain.Entities;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class CreateMeasurementCommandHandler : IHandler<CreateMeasurementCommand>
    {
        private readonly MeasurementsRepository _measurementsRepository;
        private readonly IMapper _mapper;

        public CreateMeasurementCommandHandler(MeasurementsRepository measurementsRepository, IMapper mapper)
        {
            _measurementsRepository = measurementsRepository;
            _mapper = mapper;
        }

        public async Task<RequestResult> Handle(CreateMeasurementCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var measurementsEntity = _mapper.Map<MeasurementsEntity>(command);

                if (!measurementsEntity.IsValid)
                {
                    return requestResult.BadRequest("Inform a valid value");
                }

                await _measurementsRepository.Add(measurementsEntity);
                return requestResult.Ok(measurementsEntity);
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

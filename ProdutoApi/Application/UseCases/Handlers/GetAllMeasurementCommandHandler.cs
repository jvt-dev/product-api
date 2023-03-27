using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class GetAllMeasurementCommandHandler : IHandler<GetAllCommand>
    {
        private readonly MeasurementsRepository _measurementsRepository;

        public GetAllMeasurementCommandHandler(MeasurementsRepository measurementsRepository)
        {
            _measurementsRepository = measurementsRepository;
        }

        public async Task<RequestResult> Handle(GetAllCommand command)
        {
            var requestResult = new RequestResult();
            var entities = await _measurementsRepository.GetAll();

            return requestResult.Ok(entities);
        }
    }
}

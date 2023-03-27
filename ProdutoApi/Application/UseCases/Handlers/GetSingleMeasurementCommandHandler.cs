using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class GetSingleMeasurementCommandHandler : IHandler<GetSingleCommand>
    {
        public readonly MeasurementsRepository _measurementsRepository;

        public GetSingleMeasurementCommandHandler(MeasurementsRepository measurementsRepository)
        {
            _measurementsRepository = measurementsRepository;
        }

        public async Task<RequestResult> Handle(GetSingleCommand command)
        {
            var requestResult = new RequestResult();

            var entity = await _measurementsRepository.GetEntityById(command.Id);

            if (entity is null)
            {
                return requestResult.BadRequest("Inform a valid id");
            }

            return requestResult.Ok(entity);
        }
    }
}

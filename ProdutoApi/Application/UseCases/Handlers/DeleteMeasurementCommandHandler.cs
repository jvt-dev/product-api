using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class DeleteMeasurementCommandHandler : IHandler<DeleteCommand>
    {
        private readonly MeasurementsRepository _measurementsRepository;

        public DeleteMeasurementCommandHandler(MeasurementsRepository measurementsRepository)
        {
            _measurementsRepository = measurementsRepository;
        }

        public async Task<RequestResult> Handle(DeleteCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var entity = await _measurementsRepository.GetEntityById(command.Id);

                if (entity is null)
                {
                    return requestResult.BadRequest("Inform a valid id");
                }

                await _measurementsRepository.Delete(entity);

                return requestResult.Ok();
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

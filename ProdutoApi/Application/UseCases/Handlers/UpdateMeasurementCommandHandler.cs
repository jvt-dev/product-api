using ProdutoApi.Application.Repositories;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public class UpdateMeasurementCommandHandler : IHandler<UpdateMeasurementCommand>
    {
        private readonly MeasurementsRepository _measurementsRepository;

        public UpdateMeasurementCommandHandler(MeasurementsRepository measurementsRepository)
        {
            _measurementsRepository = measurementsRepository;
        }

        public async Task<RequestResult> Handle(UpdateMeasurementCommand command)
        {
            var requestResult = new RequestResult();

            try
            {
                var entity = await _measurementsRepository.GetEntityById(command.Id);

                if(entity is null)
                {
                    return requestResult.BadRequest("Inform a valid id");
                }

                entity.UpdateDescription(command.Description);

                if(!entity.IsValid)
                {
                    return requestResult.BadRequest("Inform a valid description");
                }

                await _measurementsRepository.Update(entity);

                return requestResult.Ok(entity);
            }
            catch (Exception ex)
            {
                return requestResult.BadRequest($"{ex.Message}", command);
            }
        }
    }
}

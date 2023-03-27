using Microsoft.AspNetCore.Mvc;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Application.UseCases.Handlers;

namespace ProdutoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementsController : ControllerBase
    {
        [HttpPost("[Action]")]
        public async Task<RequestResult> CreateMeasurement([FromBody] CreateMeasurementCommand command, [FromServices] CreateMeasurementCommandHandler handler)
        {
            return await handler.Handle(command);
        }

        [HttpDelete("[Action]")]
        public async Task<RequestResult> DeleteMeasurement([FromBody] DeleteCommand command, [FromServices] DeleteMeasurementCommandHandler handler)
        {
            return await handler.Handle(command);
        }

        [HttpGet("[Action]/{id}")]
        public async Task<RequestResult> GetSingleMeasurementById([FromRoute] long id, [FromServices] GetSingleMeasurementCommandHandler handler)
        {
            GetSingleCommand command = new()
            {
                Id = id
            };

            return await handler.Handle(command);
        }

        [HttpGet("[Action]")]
        public async Task<RequestResult> GetAllMeasurements([FromServices] GetAllMeasurementCommandHandler handler)
        {
            var command = new GetAllCommand();

            return await handler.Handle(command);
        }

        [HttpPatch("[Action]")]
        public async Task<RequestResult> UpdateMeasurement([FromBody] UpdateMeasurementCommand command,[FromServices] UpdateMeasurementCommandHandler handler)
        {
            return await handler.Handle(command);
        }
    }
}

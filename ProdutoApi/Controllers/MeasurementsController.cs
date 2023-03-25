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
    }
}

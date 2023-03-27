using Microsoft.AspNetCore.Mvc;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Application.UseCases.Handlers;

namespace ProdutoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : ControllerBase
    {
        [HttpPost("[Action]")]
        public async Task<RequestResult> CreateTax([FromBody] CreateTaxCommand command, [FromServices]CreateTaxCommandHandler handler)
        {
            return await handler.Handle(command);
        }

        [HttpDelete("[Action]")]
        public async Task<RequestResult> DeleteTax([FromBody] DeleteCommand command, [FromServices] DeleteTaxCommandHandler handler)
        {
            return await handler.Handle(command);
        }

        [HttpGet("[Action]/{id}")]
        public async Task<RequestResult> GetSingleTaxById([FromRoute] long id, [FromServices] GetSingleTaxCommandHandler handler)
        {
            GetSingleCommand command = new()
            {
                Id = id
            };

            return await handler.Handle(command);
        }

        [HttpGet("[Action]")]
        public async Task<RequestResult> GetAllTaxes([FromServices] GetAllTaxCommandHandler handler)
        {
            var command = new GetAllCommand();

            return await handler.Handle(command);
        }

        [HttpPatch("[Action]")]
        public async Task<RequestResult> UpdateTax([FromBody] UpdateTaxCommand command, [FromServices] UpdateTaxCommandHandler handler)
        {
            return await handler.Handle(command);
        }
    }
}
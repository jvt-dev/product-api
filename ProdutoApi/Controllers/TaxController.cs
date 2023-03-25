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
    }
}
using Microsoft.AspNetCore.Mvc;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Application.UseCases.Handlers;

namespace ProdutoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductTypeController : ControllerBase
    {
        [HttpPost("[Action]")]
        public async Task<RequestResult> CreateProductType([FromBody] CreateProductTypeCommand command, [FromServices] CreateProductTypeCommandHandler handler)
        {
            return await handler.Handle(command);
        }

        [HttpDelete("[Action]")]
        public async Task<RequestResult> DeleteProductType([FromBody] DeleteCommand command, [FromServices] DeleteProductTypeCommandHandler handler)
        {
            return await handler.Handle(command);
        }

        [HttpGet("[Action]/{id}")]
        public async Task<RequestResult> GetSingleProductTypeById([FromRoute] long id, [FromServices] GetSingleProductTypeCommandHandler handler)
        {
            GetSingleCommand command = new()
            {
                Id = id
            };

            return await handler.Handle(command);
        }

        [HttpGet("[Action]")]
        public async Task<RequestResult> GetAllProductTypes([FromServices] GetAllProductTypeCommandHandler handler)
        {
            var command = new GetAllCommand();

            return await handler.Handle(command);
        }

        [HttpPatch("[Action]")]
        public async Task<RequestResult> UpdateProductType([FromBody] UpdateProductTypeCommand command, [FromServices] UpdateProductTypeCommandHandler handler)
        {
            return await handler.Handle(command);
        }
    }
}

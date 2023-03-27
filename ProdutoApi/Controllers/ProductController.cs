using Microsoft.AspNetCore.Mvc;
using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;
using ProdutoApi.Application.UseCases.Handlers;

namespace ProdutoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        [HttpPost("[Action]")]
        public async Task<RequestResult> CreateProduct([FromBody] CreateProductCommand command, [FromServices] CreateProductCommandHandler handler)
        {
            return await handler.Handle(command);
        }

        [HttpDelete("[Action]")]
        public async Task<RequestResult> DeleteProduct([FromBody] DeleteCommand command, [FromServices] DeleteProductCommandHandler handler)
        {
            return await handler.Handle(command);
        }

        [HttpGet("[Action]/{id}")]
        public async Task<RequestResult> GetSingleProductById([FromRoute] long id, [FromServices] GetSingleProductCommandHandler handler)
        {
            GetSingleCommand command = new()
            {
                Id = id
            };

            return await handler.Handle(command);
        }

        [HttpGet("[Action]")]
        public async Task<RequestResult> GetAllProducts([FromServices] GetAllProductCommandHandler handler)
        {
            var command = new GetAllCommand();

            return await handler.Handle(command);
        }

        [HttpPatch("[Action]")]
        public async Task<RequestResult> UpdateProduct([FromBody] UpdateProductCommand command, [FromServices] UpdateProductCommandHandler handler)
        {
            return await handler.Handle(command);
        }

        [HttpGet("[Action]")]
        public async Task<RequestResult> GetAllProductsWithStock([FromServices] GetAllProductsWithStockCommandHandler handler)
        {
            var command = new GetAllProductsWithStockCommand();

            return await handler.Handle(command);
        }
    }
}

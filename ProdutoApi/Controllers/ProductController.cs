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
    }
}

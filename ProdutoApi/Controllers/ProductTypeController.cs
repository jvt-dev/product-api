﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
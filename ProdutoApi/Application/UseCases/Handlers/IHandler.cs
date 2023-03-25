using ProdutoApi.Application.Results;
using ProdutoApi.Application.UseCases.Commands;

namespace ProdutoApi.Application.UseCases.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<RequestResult> Handle(T command);
    }
}

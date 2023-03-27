namespace ProdutoApi.Application.UseCases.Commands
{
    public class DeleteCommand : ICommand
    {
        public long Id { get; set; }
    }
}

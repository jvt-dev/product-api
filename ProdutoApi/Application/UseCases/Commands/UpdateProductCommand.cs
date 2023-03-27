namespace ProdutoApi.Application.UseCases.Commands
{
    public class UpdateProductCommand : ICommand
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
    }
}

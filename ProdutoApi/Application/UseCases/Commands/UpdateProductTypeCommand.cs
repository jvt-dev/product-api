namespace ProdutoApi.Application.UseCases.Commands
{
    public class UpdateProductTypeCommand : ICommand
    {
        public long Id { get; set; }
        public double Price { get; set; }
    }
}

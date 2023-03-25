namespace ProdutoApi.Application.UseCases.Commands
{
    public class CreateProductCommand : ICommand
    {
        public int Quantity { get; set; }
        public long ProductTypeId { get; set; }
    }
}

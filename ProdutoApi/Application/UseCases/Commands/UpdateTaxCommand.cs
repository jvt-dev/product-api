namespace ProdutoApi.Application.UseCases.Commands
{
    public class UpdateTaxCommand : ICommand
    {
        public long Id { get; set; }
        public double Value { get; set; }
    }
}

namespace ProdutoApi.Application.UseCases.Commands
{
    public class UpdateMeasurementCommand : ICommand
    {
        public long Id { get; set; }
        public string Description { get; set; }
    }
}

namespace ProdutoApi.Application.UseCases.Commands
{
    public class CreateProductTypeCommand : ICommand
    {
        public string Description { get; set; }
        public long MeasurementsId { get; set; }
        public long TaxId { get; set; }
        public double MeasurementValue { get; set; }
        public double Price { get; set; }
    }
}

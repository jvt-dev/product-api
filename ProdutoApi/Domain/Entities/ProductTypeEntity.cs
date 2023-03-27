using System.ComponentModel.DataAnnotations.Schema;

namespace ProdutoApi.Domain.Entities
{
    public class ProductTypeEntity : Entity
    {
        public string Description { get; private set; }
        public double MeasurementValue { get; private set; }
        public double Price { get; private set; }
        public bool IsValid => Validate();

        [ForeignKey("MeasurementsId")]
        public MeasurementsEntity Measurements { get; private set; }
        [ForeignKey("TaxId")]
        public TaxEntity Tax { get; private set; }

        private bool Validate()
        {
            if(!string.IsNullOrEmpty(Description) 
                && Measurements?.Id != 0 
                && Tax?.Id != 0
                && MeasurementValue != 0
                && Price != 0)
            {
                return true;
            }

            return false;
        }

        public void UpdatePrice(double price)
        {
            Price = price;
        }
    }
}

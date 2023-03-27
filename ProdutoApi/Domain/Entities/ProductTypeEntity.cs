using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProdutoApi.Domain.Entities
{
    public class ProductTypeEntity : Entity
    {
        public string Description { get; private set; }
        public double MeasurementValue { get; private set; }
        public double Price { get; private set; }

        [JsonIgnore]
        public long MeasurementsId { get; private set; }
        [ForeignKey("MeasurementsId")]
        public MeasurementsEntity? Measurements { get; private set; }

        [JsonIgnore]
        public long TaxId { get; private set; }
        [ForeignKey("TaxId")]
        public TaxEntity? Tax { get; private set; }

        [JsonIgnore]
        public bool IsValid => Validate();

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

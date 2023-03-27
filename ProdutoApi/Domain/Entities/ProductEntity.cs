using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProdutoApi.Domain.Entities
{
    public class ProductEntity : Entity
    {
        public int Quantity { get; private set; }        
        public double FinalPrice => SetFinalPrice();

        [JsonIgnore]
        public long ProductTypeId { get; private set; }
        [ForeignKey("ProductTypeId")]
        public ProductTypeEntity? ProductType { get; private set; }

        [JsonIgnore]
        public bool IsValid => Validate();

        private double SetFinalPrice()
        {
            return ProductType.Price * Quantity + ProductType.Price * ProductType.Tax.Value;
        }

        private bool Validate()
        {
            return ProductType?.Id != 0;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public bool HasStock()
        {
            return Quantity > 0;
        }

        public bool ValidateFinalPriceValue()
        {
            return FinalPrice >= 100 && FinalPrice <= 500;
        }
    }
}

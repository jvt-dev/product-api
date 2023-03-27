using System.ComponentModel.DataAnnotations.Schema;

namespace ProdutoApi.Domain.Entities
{
    public class ProductEntity : Entity
    {
        public int Quantity { get; private set; }        
        public double FinalPrice => SetFinalPrice();
        public bool IsValid => Validate();

        [ForeignKey("ProductTypeId")]
        public ProductTypeEntity ProductType { get; private set; }


        private double SetFinalPrice()
        {
            return ProductType.Price * Quantity + ProductType.Price * ProductType.Tax.Value;
        }

        private bool Validate()
        {
            return Quantity != 0 && ProductType?.Id != 0;
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}

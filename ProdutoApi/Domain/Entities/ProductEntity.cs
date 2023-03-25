namespace ProdutoApi.Domain.Entities
{
    public class ProductEntity : Entity
    {
        public int Quantity { get; private set; }
        public ProductTypeEntity ProductType { get; private set; }
        public double FinalPrice => SetFinalPrice();
        public bool IsValid => Validate();

        private double SetFinalPrice()
        {
            return ProductType.Price * Quantity + ProductType.Price * ProductType.Tax.Value;
        }

        private bool Validate()
        {
            return Quantity != 0 && ProductType?.Id != 0;
        }
    }
}

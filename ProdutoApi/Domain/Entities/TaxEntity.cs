using System.Text.Json.Serialization;

namespace ProdutoApi.Domain.Entities
{
    public class TaxEntity : Entity
    {
        public double Value { get; private set; }
        [JsonIgnore]
        public bool IsValid => Validate();

        private bool Validate()
        {
            return Value != 0;
        }

        public void UpdateValue(double value) => Value = value;
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace ProdutoApi.Domain.Entities
{
    public class TaxEntity : Entity
    {
        public double Value { get; private set; }
        public bool IsValid => Validate();

        private bool Validate()
        {
            return Value != 0;
        }
    }
}

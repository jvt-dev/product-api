using System.Text.Json.Serialization;

namespace ProdutoApi.Domain.Entities
{
    public class MeasurementsEntity : Entity
    {
        public string Description { get; private set; }
        [JsonIgnore]
        public bool IsValid => Validate();

        private bool Validate()
        {
            return !string.IsNullOrEmpty(Description);
        }

        public void UpdateDescription(string descripition) => Description = descripition;
    }
}

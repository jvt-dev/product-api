namespace ProdutoApi.Domain.Entities
{
    public class MeasurementsEntity : Entity
    {
        public string Description { get; private set; }
        public bool IsValid => Validate();

        private bool Validate()
        {
            return !string.IsNullOrEmpty(Description);
        }

        public void UpdateDescription(string descripition) => Description = descripition;
    }
}

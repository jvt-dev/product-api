using System.ComponentModel.DataAnnotations.Schema;

namespace ProdutoApi.Domain.Entities
{
    public abstract class Entity
    {
        public long Id { get; private set; }
    }
}

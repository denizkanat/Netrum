using Infrastructure.Model;

namespace Netrum.Model.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }


        public List<Movie>? Movies { get; set; }
    }
}

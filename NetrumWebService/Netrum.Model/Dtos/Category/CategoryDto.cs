using Infrastructure.Model;

namespace Netrum.Model.Dtos.Category
{
    public class CategoryDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

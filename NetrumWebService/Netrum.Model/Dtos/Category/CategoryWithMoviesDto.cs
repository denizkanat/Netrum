using Infrastructure.Model;
using Netrum.Model.Dtos.Movie;

namespace Netrum.Model.Dtos.Category
{
    public class CategoryWithMoviesDto : CategoryDto, IDto
    {
        public List<MovieDto> Movies { get; set; }
    }
}

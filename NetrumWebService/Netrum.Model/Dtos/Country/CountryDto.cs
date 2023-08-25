using Infrastructure.Model;

namespace Netrum.Model.Dtos.Country
{
    public class CountryDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

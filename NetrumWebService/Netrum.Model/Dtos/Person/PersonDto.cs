using Infrastructure.Model;


namespace Netrum.Model.Dtos.Person
{
    public class PersonDto : IDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int? Age { get; set; }
        public string? CountryName { get; set; }
        public string? GenderName { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public double? Points { get; set; }
        }
}

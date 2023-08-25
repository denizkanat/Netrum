using Infrastructure.Model;

namespace Netrum.Model.Dtos.Movie
{
    public class MovieDto : IDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string CategoryName { get; set; }
        public int Duration { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public string? Trailer { get; set; }
        public double? Points { get; set; }
       }
}

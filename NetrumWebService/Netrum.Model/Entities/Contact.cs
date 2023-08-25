using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netrum.Model.Entities
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CountryId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        [NotMapped]
        public string FullName { get { return $"{Firstname} {Lastname}"; } }
        
        public Country Country { get; set; }
    }
}

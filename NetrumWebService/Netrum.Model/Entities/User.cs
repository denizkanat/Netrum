using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netrum.Model.Entities
{
    public class User : IEntity
    {
        public string Nickname { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        [NotMapped]
        public string? FullName { get { return $"{Firstname} {Lastname}"; } }
        
    }
}

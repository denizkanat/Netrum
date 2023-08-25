using Infrastructure.Model;

namespace Netrum.Model.Entities
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public List<Person>? Persons { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}

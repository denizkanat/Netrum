using Infrastructure.Model;
using Netrum.Model.Dtos.Person;

namespace Netrum.Model.Dtos.Country
{
    public class CountryWithPersonsDto : CountryDto, IDto
    {
        public List<PersonDto>? Persons { get; set; }
    }
}

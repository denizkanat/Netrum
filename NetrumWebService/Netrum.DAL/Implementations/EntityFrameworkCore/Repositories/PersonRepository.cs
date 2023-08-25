using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using Netrum.Model.Entities;

namespace Netrum.DAL.Implementations.EntityFrameworkCore.Repositories
{
    using Contexts;
    using Interfaces;

    public class PersonRepository : BaseRepository<Person, NetrumContext>, IPersonRepository
    {
        public async Task<Person> GetPersonByIdAsync(int personId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == personId, includeList);
        }

        public async Task<List<Person>> GetPersonsByAgeRangeAsync(int min, int max, params string[] includeList)
        {
            return await GetAllAsync(prd => DateTime.Now.Year - prd.Birthdate.Value.Year >= min && DateTime.Now.Year - prd.Birthdate.Value.Year <= max, includeList: includeList);
        }
        
    }
}

namespace Netrum.DAL.Implementations.EntityFrameworkCore.Repositories
{
    using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
    using Contexts;
    using Interfaces;
    using Model.Entities;

    public class CountryRepository : BaseRepository<Country, NetrumContext>, ICountryRepository
    {
        public async Task<Country> GetByIdAsync(int countryId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == countryId, includeList);
        }

        public async Task<Country> GetSingleCountryByIdWithPersonsAsync(int countryId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == countryId, includeList);
        }
    }
}

namespace Netrum.DAL.Interfaces
{
    using Infrastructure.DataAccess.Interfaces;
    using Model.Entities;

    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<Country> GetByIdAsync(int countryId, params string[] includeList);
        Task<Country> GetSingleCountryByIdWithPersonsAsync(int countryId, params string[] includeList);
    }
}

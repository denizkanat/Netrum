namespace Netrum.DAL.Interfaces
{
    using Infrastructure.DataAccess.Interfaces;
    using Model.Entities;

    public interface IPersonRepository : IBaseRepository<Person>
    {
        Task<Person> GetPersonByIdAsync(int personId, params string[] includeList);
        Task<List<Person>> GetPersonsByAgeRangeAsync(int min, int max, params string[] includeList);

    }
}

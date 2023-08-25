namespace Netrum.DAL.Interfaces
{
    using Infrastructure.DataAccess.Interfaces;
    using Model.Entities;

    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<Contact> GetContactByIdAsync(int id, params string[] includeList);
    }
}

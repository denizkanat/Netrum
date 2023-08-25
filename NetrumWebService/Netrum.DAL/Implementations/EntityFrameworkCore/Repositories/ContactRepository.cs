namespace Netrum.DAL.Implementations.EntityFrameworkCore.Repositories
{
    using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
    using Contexts;
    using Interfaces;
    using Model.Entities;

    public class ContactRepository : BaseRepository<Contact, NetrumContext>, IContactRepository
    {
        public async Task<Contact> GetContactByIdAsync(int id, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == id, includeList);
        }
    }
}

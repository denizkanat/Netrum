namespace Netrum.DAL.Implementations.EntityFrameworkCore.Repositories
{
    using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
    using Contexts;
    using Interfaces;
    using Model.Entities;

    public class AdminRepository : BaseRepository<Admin, NetrumContext>, IAdminRepository
    {
        public Task<Admin> GetByUserNameAndPasswordAsync(string userName, string password)
        {
            return GetAsync(prd => prd.Username == userName && prd.Password == password);
        }
    }
}

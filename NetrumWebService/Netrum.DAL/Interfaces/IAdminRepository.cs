using Infrastructure.DataAccess.Interfaces;
using Netrum.Model.Entities;

namespace Netrum.DAL.Interfaces
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Task<Admin> GetByUserNameAndPasswordAsync(string userName, string password);
    }
}

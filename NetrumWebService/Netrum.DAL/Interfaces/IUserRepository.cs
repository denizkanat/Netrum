namespace Netrum.DAL.Interfaces
{
    using Infrastructure.DataAccess.Interfaces;
    using Model.Entities;

    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByIdAsync(string nickName, params string[] includeList);
        Task<List<User>> GetByFullNameAsync(string fullName, params string[] includeList); 
        Task<User> GetUserByNicknameWithPasswordAsync(string nickName, string password, params string[] includeList);
    }
}

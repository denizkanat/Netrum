namespace Netrum.DAL.Implementations.EntityFrameworkCore.Repositories
{
    using Contexts;
    using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
    using Interfaces;
    using Model.Entities;

    public class UserRepository : BaseRepository<User, NetrumContext>, IUserRepository
    {
        public async Task<List<User>> GetByFullNameAsync(string fullName, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Firstname.ToLower() + " " + prd.Lastname.ToLower() == fullName.ToLower(), includeList: includeList);
        }

        public async Task<User> GetByIdAsync(string nickName, params string[] includeList)
        {
            return await GetAsync(prd => prd.Nickname.ToLower() == nickName.ToLower(), includeList);
        }

        public async Task<User> GetUserByNicknameWithPasswordAsync(string nickName, string password, params string[] includeList)
        {
            return await GetAsync(prd => prd.Nickname == nickName && prd.Password == password, includeList);
        }
    }
}

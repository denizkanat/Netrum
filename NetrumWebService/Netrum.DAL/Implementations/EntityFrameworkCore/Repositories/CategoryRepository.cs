namespace Netrum.DAL.Implementations.EntityFrameworkCore.Repositories
{
    using Contexts;
    using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
    using Interfaces;
    using Model.Entities;

    public class CategoryRepository : BaseRepository<Category, NetrumContext>, ICategoryRepository
    {
        public async Task<Category> GetByIdAsync(int categoryId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == categoryId, includeList);
        }

        public async Task<Category> GetSingleCategoryByIdWithMoviesAsync(int categoryId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == categoryId, includeList);
        }
    }
}

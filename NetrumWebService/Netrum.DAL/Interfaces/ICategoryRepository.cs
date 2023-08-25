namespace Netrum.DAL.Interfaces
{
    using Infrastructure.DataAccess.Interfaces;
    using Model.Entities;

    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetByIdAsync(int categoryId, params string[] includeList);
        Task<Category> GetSingleCategoryByIdWithMoviesAsync(int categoryId, params string[] includeList);
    }
}

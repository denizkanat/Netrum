namespace Netrum.Business.Interfaces
{
    using Infrastructure.Utilities.ApiResponses;
    using Model.Dtos.Category;

    public interface ICategoryService
    {
        Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id);
        Task<ApiResponse<CategoryWithMoviesDto>> GetSingleCategoryByIdWithMoviesAsync(int id, params string[] includeList);
        Task<ApiResponse<List<CategoryDto>>> GetCategoriesAsync();
        Task<ApiResponse<List<CategoryWithMoviesDto>>> GetCategoriesWithMoviesAsync(params string[] includeList);
        Task<ApiResponse<CategoryDto>> AddAsync(CategoryPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

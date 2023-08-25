namespace Netrum.Business.Implementations
{
    using AutoMapper;
    using Constants;
    using Infrastructure.CustomExceptions;
    using Infrastructure.Utilities.ApiResponses;
    using Interfaces;
    using Microsoft.AspNetCore.Http;
    using Netrum.DAL.Interfaces;
    using Model.Dtos.Category;
    using Model.Entities;

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        
        public async Task<ApiResponse<CategoryDto>> AddAsync(CategoryPostDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            var insertedCategory = await _repository.AddAsync(category);
            var response = await GetCategoryByIdAsync(insertedCategory.Id);
            return ApiResponse<CategoryDto>.Success(StatusCodes.Status201Created, response.Data);
        }

     
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category != null)
            {
                await _repository.RemoveAsync(category);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }

       
        public async Task<ApiResponse<List<CategoryDto>>> GetCategoriesAsync()
        {
            var categories = await _repository.GetAllAsync();
            if (categories != null && categories.Count > 0)
            {
                var returnList = _mapper.Map<List<CategoryDto>>(categories);
                return ApiResponse<List<CategoryDto>>.Success(StatusCodes.Status200OK, returnList);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }
        
        public async Task<ApiResponse<List<CategoryWithMoviesDto>>> GetCategoriesWithMoviesAsync(params string[] includeList)
        {
            var categoriesWithMovies = await _repository.GetAllAsync(includeList: includeList);
            if (categoriesWithMovies != null && categoriesWithMovies.Count > 0)
            {
                var dto = _mapper.Map<List<CategoryWithMoviesDto>>(categoriesWithMovies);
                return ApiResponse<List<CategoryWithMoviesDto>>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundContent);
        }
        
        public async Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category != null)
            {
                var dto = _mapper.Map<CategoryDto>(category);
                return ApiResponse<CategoryDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }
        
        public async Task<ApiResponse<CategoryWithMoviesDto>> GetSingleCategoryByIdWithMoviesAsync(int id, params string[] includeList)
        {
            var categoryWithMovies = await _repository.GetSingleCategoryByIdWithMoviesAsync(id, includeList);
            if (categoryWithMovies != null)
            {
                var dto = _mapper.Map<CategoryWithMoviesDto>(categoryWithMovies);
                return ApiResponse<CategoryWithMoviesDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }
        
        public async Task<ApiResponse<NoData>> UpdateAsync(CategoryPutDto dto)
        {
            var category = await _repository.GetByIdAsync(dto.Id);
            if (category != null)
            {
                var updateCategory = _mapper.Map<Category>(dto);
                await _repository.UpdateAsync(updateCategory);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException(ErrorMessages.NotFoundId);
        }
    }
}

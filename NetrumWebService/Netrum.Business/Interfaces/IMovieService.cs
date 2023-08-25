namespace Netrum.Business.Interfaces
{
    using Infrastructure.Utilities.ApiResponses;
    using Model.Dtos.Movie;

    public interface IMovieService
    {
        Task<ApiResponse<List<MovieDto>>> GetMoviesAsync(params string[] includeList);
        Task<ApiResponse<MovieDto>> GetMovieByIdAsync(int id, params string[] includeList);
        Task<ApiResponse<List<MovieDto>>> GetMoviesByReleaseDateRangeAsync(DateTime start, DateTime end, params string[] includeList);
        Task<ApiResponse<List<MovieDto>>> GetMoviesByDurationRangeAsync(int min, int max, params string[] includeList);
        Task<ApiResponse<MovieDto>> AddAsync(MoviePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(MoviePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

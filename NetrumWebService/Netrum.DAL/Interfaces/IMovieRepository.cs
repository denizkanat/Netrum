using Infrastructure.DataAccess.Interfaces;
using Netrum.Model.Entities;

namespace Netrum.DAL.Interfaces
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<Movie> GetByIdAsync(int movieId, params string[] includeList);
        Task<List<Movie>> GetMoviesByReleaseDateRangeAsync(DateTime start, DateTime end, params string[] includeList);
        Task<List<Movie>> GetMoviesByDurationRangeAsync(int min, int max, params string[] includeList);
    }
}

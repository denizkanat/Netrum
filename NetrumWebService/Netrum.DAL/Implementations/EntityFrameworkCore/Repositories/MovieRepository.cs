using Infrastructure.DataAccess.Implementations.EntityFrameworkCore;
using Netrum.Model.Entities;

namespace Netrum.DAL.Implementations.EntityFrameworkCore.Repositories
{
    using Contexts;
    using Interfaces;

    public class MovieRepository : BaseRepository<Movie, NetrumContext>, IMovieRepository
    {
        public async Task<Movie> GetByIdAsync(int movieId, params string[] includeList)
        {
            return await GetAsync(prd => prd.Id == movieId, includeList);
        }

        public async Task<List<Movie>> GetMoviesByDurationRangeAsync(int min, int max, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.Duration >= min && prd.Duration <= max, includeList: includeList);
        }

        public async Task<List<Movie>> GetMoviesByReleaseDateRangeAsync(DateTime start, DateTime end, params string[] includeList)
        {
            return await GetAllAsync(prd => prd.ReleaseDate >= start && prd.ReleaseDate <= end, includeList: includeList);
        }

      
    }
}

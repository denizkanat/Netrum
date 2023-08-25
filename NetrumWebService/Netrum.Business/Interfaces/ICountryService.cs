namespace Netrum.Business.Interfaces
{
    using Infrastructure.Utilities.ApiResponses;
    using Model.Dtos.Country;

    public interface ICountryService
    {
        Task<ApiResponse<CountryDto>> GetCountryById(int id);
        Task<ApiResponse<CountryWithPersonsDto>> GetSingleCountryByIdWithPersonsAsync(int countryId, params string[] includeList);
        Task<ApiResponse<List<CountryDto>>> GetCountriesAsync();
        Task<ApiResponse<List<CountryWithPersonsDto>>> GetCountriesWithPersonsAsync(params string[] includeList);
        Task<ApiResponse<CountryDto>> AddAsync(CountryPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CountryPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}

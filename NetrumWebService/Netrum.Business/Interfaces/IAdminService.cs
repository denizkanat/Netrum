namespace Netrum.Business.Interfaces
{
    using Infrastructure.Utilities.ApiResponses;
    using Model.Dtos.Admin;

    public interface IAdminService
    {
        Task<ApiResponse<AdminDto>> LogInAsync(string userName, string password);
    }
}

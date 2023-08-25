namespace Netrum.Business.Interfaces
{
    using Infrastructure.Utilities.ApiResponses;
    using Model.Dtos.Contact;

    public interface IContactService
    {
        Task<ApiResponse<List<ContactDto>>> GetContactsAsync(params string[] includeList);
        Task<ApiResponse<ContactDto>> GetContactAsync(int id, params string[] includeList);
        Task<ApiResponse<ContactDto>> AddContactAsync(ContactPostDto dto);
    }
}

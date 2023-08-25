namespace Netrum.Business.Implementations
{
    using AutoMapper;
    using Constants;
    using Infrastructure.CustomExceptions;
    using Infrastructure.Utilities.ApiResponses;
    using Microsoft.AspNetCore.Http;
    using Interfaces;
    using Netrum.DAL.Interfaces;
    using Model.Dtos.Admin;

    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        public async Task<ApiResponse<AdminDto>> LogInAsync(string userName, string password)
        {
            var adminUser = await _repository.GetByUserNameAndPasswordAsync(userName, password);
            if (adminUser != null)
            {
                var dto = _mapper.Map<AdminDto>(adminUser);
                return ApiResponse<AdminDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException(ErrorMessages.LogInError);
        }
    }
}

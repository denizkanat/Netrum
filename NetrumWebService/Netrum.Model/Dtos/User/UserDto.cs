using Infrastructure.Model;


namespace Netrum.Model.Dtos.User
{
    public class UserDto : IDto
    {
        public string Nickname { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
       }
}

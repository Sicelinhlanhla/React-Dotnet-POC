using POC.API.Dtos;

namespace POC.API.Services
{
    public interface IUserService
    {
        Task RegisterUser(RegisterDto userDto);
        Task<string> LoginUser(LoginDto userDto);

        Task<UserDto> GetUserById(Guid id);
    }
}

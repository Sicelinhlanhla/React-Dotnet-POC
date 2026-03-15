using Microsoft.EntityFrameworkCore;
using POC.API.Domain.Entities;
using POC.API.Dtos;
using POC.API.Infrastructure.Data;

namespace POC.API.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> LoginUser(LoginDto userDto)
        {
            string loginResults = string.Empty;
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.Email == userDto.Email);


                if(user !=null) {
                    var validUserLogin = BCrypt.Net.BCrypt.Verify(
                                         userDto.Password,
                                         user.PasswordHash);
                    if (validUserLogin)
                    {
                        loginResults = "Login Success";
                    }
                }
                return loginResults;
            }
            catch (Exception ex)
            {
                return "Login Failed";
            }
            
        }

        public async Task RegisterUser(RegisterDto userDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                Email = userDto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            var userDto = new UserDto
            {
                Email = user.Email,
                Name = user.Name,
                CreatedAt = user.CreatedAt
            };

            return userDto;
        }
    }
}

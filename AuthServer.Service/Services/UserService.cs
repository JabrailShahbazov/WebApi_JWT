using System.Linq;
using System.Threading.Tasks;
using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using AuthServer.Core.Services;
using AuthServer.Shared.Dtos;
using Microsoft.AspNetCore.Identity;

namespace AuthServer.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;

        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new UserApp
            {
                Email = createUserDto.Email,
                UserName = createUserDto.UserName
            };
            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (result.Succeeded) return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
            
            var error = result.Errors.Select(x => x.Description).ToList();
            return Response<UserAppDto>.Fail(new ErrorDto(error, true), 400);

        }

        public async Task<Response<UserAppDto>> GetUserByName(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            return user == null
                ? Response<UserAppDto>.Fail("UserName not found", 404, true)
                : Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }
    }
}
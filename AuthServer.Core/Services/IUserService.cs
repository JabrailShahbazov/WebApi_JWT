using System.Threading.Tasks;
using AuthServer.Core.DTOs;
using AuthServer.Shared.Dtos;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<Response<UserAppDto>> GetUserByName(string userName);
    }
}
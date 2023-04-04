using OnPeople.Application.Dtos.Users;

namespace OnPeople.Application.Services.Contracts.Users
{
    public interface ITokenServices
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}
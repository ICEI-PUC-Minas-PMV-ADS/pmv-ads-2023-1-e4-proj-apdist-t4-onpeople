using Microsoft.AspNetCore.Identity;
using OnPeople.Application.Dtos.Users;

namespace OnPeople.Application.Services.Contracts.Users
{
    public interface IUsersServices
    {
        Task<UserUpdateDto> UpdateUserTokenAsync(UserUpdateDto userUpdateDto);
        Task<UserVisaoDto> UpdateUserVisaoAsync(UserVisaoDto userVisaoDto);
        Task<UserUpdateDto> CreateUsersAsync(UserDto userDto);
        Task<UserDto> GetUserByIdAsync(int UserId);
        Task<UserUpdateDto> GetUserByUserNameAsync(string userName);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password);
        Task<bool> VerifyUserExistsAsync(string userName);
        Task<UserVisaoDto> GetVisaoByUserNameAsync(string userName);
    }
}
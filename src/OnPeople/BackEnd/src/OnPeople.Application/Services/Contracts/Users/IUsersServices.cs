using Microsoft.AspNetCore.Identity;
using OnPeople.Application.Dtos.Users;

namespace OnPeople.Application.Services.Contracts.Users
{
    public interface IUsersServices
    {
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password);
        Task<UserUpdateDto> CreateUsersAsync(UserDto userDto);
        Task<UserDto> GetUserByIdAsync(int UserId);
        Task<UserUpdateDto> GetUserByUserNameAsync(string userName);
        Task<UserUpdateDto> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<bool> VerifyUserExistsAsync(string userName);
    }
}
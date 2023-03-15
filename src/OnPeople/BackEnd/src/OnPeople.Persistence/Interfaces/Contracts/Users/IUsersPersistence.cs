using OnPeople.Domain.Models.Users;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Contracts.Users
{
    public interface IUsersPersistence : ISharedPersistence
{
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUserNameAsync(string userName);
        Task<IEnumerable<User>> GetAllUsersAtivasAsync();
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
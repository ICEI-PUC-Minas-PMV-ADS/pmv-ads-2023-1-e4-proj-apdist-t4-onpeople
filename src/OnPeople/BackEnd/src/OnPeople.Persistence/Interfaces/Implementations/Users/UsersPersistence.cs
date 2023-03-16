using Microsoft.EntityFrameworkCore;
using OnPeople.Domain.Models.Users;
using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Users;
using OnPeople.Persistence.Interfaces.Implementations.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Users
{
    public class UsersPersistence : SharedPersistence, IUsersPersistence
    {
        private readonly OnPeopleContext _context;
        public UsersPersistence(OnPeopleContext context) : base(context)
        {
            _context = context;
        }        

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            IQueryable<User> query = _context.Users
                .AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAtivasAsync()
        {
            IQueryable<User> query = _context.Users;

            query = query
                .AsNoTracking()
                .Where(c => c.Ativa == true)
                .OrderBy(c => c.Id);

            return await query.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            IQueryable<User> query = _context.Users;

            query = query
                .AsNoTracking()
                .Where(c => c.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            IQueryable<User> query = _context.Users;
                
            query = query
                .AsNoTracking()
                .Where(c => c.UserName.ToLower() == userName.ToLower());

            return await query.SingleOrDefaultAsync();
        }
        
    }
}
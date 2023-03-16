using OnPeople.Persistence.Interfaces.Contexts;
using OnPeople.Persistence.Interfaces.Contracts.Shared;

namespace OnPeople.Persistence.Interfaces.Implementations.Shared
{
    public class SharedPersistence : ISharedPersistence
    {
        private readonly OnPeopleContext _context;
        public SharedPersistence(OnPeopleContext context)
        {
           _context = context;

        }
        public void Create<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return ((await _context.SaveChangesAsync()) > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.Update(entity);
        }
    }
}
namespace OnPeople.Persistence.Interfaces.Contracts.Shared
{
    public interface ISharedPersistence
    {
         void Create<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         void DeleteRange<T>(T[] entity) where T : class;
         Task<bool> SaveChangesAsync();
    }
}
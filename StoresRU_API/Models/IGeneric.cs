namespace StoresRU_API.Models
{
    public interface IGeneric<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetByID(int id);
        void Create(T entity);
        void Update(T value);
        void Delete(T entity);
    }
}

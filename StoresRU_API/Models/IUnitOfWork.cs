namespace StoresRU_API.Models
{
    public interface IUnitOfWork: IDisposable
    {
        int Complete();
    }
}

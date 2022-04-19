namespace StoresRU_API.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        public UnitOfWork(DataContext context)
        {
            this._dbContext = context;
        }
        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

using CustomerMicroservice.DataAccess.Repositories;

namespace CustomerMicroservice.DataAccess.UoW
{
    public interface IUnitofWork
    {
        public IRepository<T> GetRepository<T>() where T : class;
        int SaveChange();
    }
}

using System.Linq.Expressions;

namespace CustomerMicroservice.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        void Add(T model);
        void Delete(T model);
        void Update(T model);
    }
}

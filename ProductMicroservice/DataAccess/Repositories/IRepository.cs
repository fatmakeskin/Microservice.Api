using ProductMicroservice.Entities;
using System.Linq.Expressions;

namespace ProductMicroservice.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        void Add(T model);
        void Update(T model);
        void Delete(Expression<Func<T, bool>> expression);
        

    }
}

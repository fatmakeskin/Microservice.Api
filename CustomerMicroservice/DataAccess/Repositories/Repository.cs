using CustomerMicroservice.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CustomerMicroservice.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> Dbset;
        public Repository(DbContext _context)
        {
            context = _context;
            Dbset = context.Set<T>();
        }
        public void Add(T model)
        {
            Dbset.Add(model);
        }

        public void Delete(T model)
        {
            context.Entry(model).State = EntityState.Deleted;
            Dbset.Attach(model);
            Dbset.Remove(model);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            var data = Dbset.Where(expression);
            return data.FirstOrDefault();
        }

        public IQueryable<T> GetAll()
        {
            var data = Dbset;
            return data;
        }

        public void Update(T model)
        {
            Dbset.Attach(model);
            context.Entry(model).State = EntityState.Modified;
        }
    }
}

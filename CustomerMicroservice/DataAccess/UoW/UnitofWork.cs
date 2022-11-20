using CustomerMicroservice.DataAccess.Context;
using CustomerMicroservice.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.DataAccess.UoW
{
    public class UnitofWork<T> : IDisposable, IUnitofWork
    {
        private DbContext context;
        public DbContext dbContext
        {
            get
            {
                if (context == null)
                    context = new MasterContext();
                return context;
            }
            set
            {
                context = value;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(context);
        }
        public int SaveChange()
        {
            return dbContext.SaveChanges();
        }
    }
}

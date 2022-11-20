using CustomerMicroservice.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroservice.DataAccess.Context
{
    public class MasterContext : DbContext
    {
        public MasterContext()
        {
        }

        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {
        }
        public DbSet<CustomerModel> CustomerModels { get; set; }
        //public DbSet<CustomerModelSecurity> CustomerModelsSecurity { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CustomerModel>().HasKey(x => x.Id);
            //modelBuilder.Entity<CustomerModelSecurity>().HasNoKey();

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("Server=localhost;Database=customermicro;Uid=root;Pwd=root;");
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    OnModelCreating(modelBuilder);
        //}
    }
}

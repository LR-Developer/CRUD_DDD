using CRUD_DDD.Domain.Entities;
using CRUD_DDD.Infra.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CRUD_DDD.Infra.Contexts
{
    public class CrudDddContext : DbContext
    {
        public CrudDddContext()
            : base("CrudDddDb")
        {
        }

        DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new CustomerConfiguration());
        }
    }
}

using CRUD_DDD.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CRUD_DDD.Infra.EntityConfig
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.BirthDate)
                .IsRequired();

            Property(c => c.Gender)
                .IsRequired();
        }
    }
}

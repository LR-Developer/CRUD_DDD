using CRUD_DDD.Domain.Contracts.Repositories;
using CRUD_DDD.Domain.Entities;
using CRUD_DDD.Infra.Contexts;

namespace CRUD_DDD.Infra.Repositories
{
    public class CustomerRepository
        : Repository<Customer>
        , ICustomerRepository
    {
        protected CustomerRepository(CrudDddContext context)
            : base(context)
        {
        }
    }
}

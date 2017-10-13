using CRUD_DDD.Domain.Contracts.Repositories;
using CRUD_DDD.Domain.Entities;

namespace CRUD_DDD.Infra.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
    }
}

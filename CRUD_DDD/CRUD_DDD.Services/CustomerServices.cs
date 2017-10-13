using CRUD_DDD.Domain.Contracts.Repositories;
using CRUD_DDD.Domain.Contracts.Services;
using CRUD_DDD.Domain.Entities;

namespace CRUD_DDD.Services
{
    public class CustomerServices : Services<Customer>, ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
            : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}

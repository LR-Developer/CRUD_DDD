using CRUD_DDD.Domain.Contracts.Repositories;
using CRUD_DDD.Domain.Entities;
using System;
using System.Linq;

namespace CRUD_DDD.Services.Customers
{
    /// <summary>
    /// Apenas lembrando que este cara é um ApplicationService.
    ///     Application services servem para orquestrar as ações do sistema
    /// </summary>
    public class CustomerService
        : ServiceBase<Customer, CustomerDto, CustomerDto, CustomerDto, CustomerDto>
        , ICustomerService
    {
        public CustomerService(
            IUnitOfWork unitOfWork,
            IRepository<Customer> repository)
            : base(unitOfWork, repository)
        {
        }

        /// <summary>
        /// Exemplo simples de validação com override do add genérico
        /// </summary>
        /// <param name="dto"></param>
        public override void Add(CustomerDto dto)
        {
            if (Repository.AsQueryable().Any(x => x.Name == dto.Name))
                throw new ApplicationException("Cliente já cadastrado");

            base.Add(dto);
        }
    }
}

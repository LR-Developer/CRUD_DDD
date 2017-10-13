using CRUD_DDD.Domain.Entities;
using System;

namespace CRUD_DDD.Services.Customers
{
    public class CustomerDto
        : IApplyChangesTo<Customer>
        , IConvertToEntity<Customer>
    {
        /// <summary>
        /// Opcional, pois tem valor apenas quando é leitura
        /// </summary>
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }

        public void ApplyChangesTo(Customer entity)
        {
            entity.BirthDate = BirthDate;
            entity.Gender = Gender;
            entity.Name = Name;
        }

        public Customer ConvertToEntity()
        {
            return Customer.Create(new CustomerParameters
            {
                Name = Name,
                Gender = Gender,
                BirthDate = BirthDate
            });
        }
    }
}
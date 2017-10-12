    using System;

namespace CRUD_DDD.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birth { get; set; }

        public string Gender { get; set; }

        public Customer()
        {

        }
    }
}

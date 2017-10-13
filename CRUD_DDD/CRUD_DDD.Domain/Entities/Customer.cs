using CRUD_DDD.Domain.Contracts.Entities;
using System;

namespace CRUD_DDD.Domain.Entities
{
    /// <summary>
    /// Encapulamento para o exemplo de abstração 1
    /// </summary>
    public class CustomerParameters
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    /// <summary>
    /// Cliente
    /// </summary>
    public class Customer
        : IAggregateRoot
    {
        //Construtor para o EF.
        private Customer() { }

        /// <summary>
        /// Asbtração 1: Possibilidade de encapsulamento com factory.
        /// </summary>
        /// <returns></returns>
        public static Customer Create(string name, string gender, DateTime? birthDate)
        {
            return new Customer
            {
                Name = name,
                Gender = gender,
                BirthDate = birthDate
            };
        }

        /// <summary>
        /// Abstração 1: Outra opão de encapsulamento com factory para muitos parâmetros
        /// </summary>
        /// <param name="parameters"></param>
        public static Customer Create(CustomerParameters parameters)
        {
            return new Customer
            {
                BirthDate = parameters.BirthDate,
                Gender = parameters.Gender,
                Name = parameters.Name
            };
        }

        /// <summary>
        /// Abstração 2: Regras de negócio encapsuladas conforme uma abstração.
        ///     "Para criar um cliente, é obrigatório ter um nome de um gênero."
        /// </summary>
        public Customer(string name, string gender)
        {
            Name = name;
            Gender = gender;
        }

        /// <summary>
        /// Abstração 3: set privado, pois o banco que irá gerar esse ID
        /// </summary>
        public int Id { get; private set; }

        public string Name { get; set; }
        public string Gender { get; set; }

        /// <summary>
        /// Abstração 4: Nulo, pois não é um campo obrigatório
        /// </summary>
        public DateTime? BirthDate { get; set; }
    }
}
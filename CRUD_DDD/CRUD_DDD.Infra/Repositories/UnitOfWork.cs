using CRUD_DDD.Domain.Contracts.Repositories;
using CRUD_DDD.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DDD.Infra.Repositories
{
    public class UnitOfWork
        : IUnitOfWork
    {
        private readonly CrudDddContext _context;

        /// <summary>
        /// Caso tenha mais de um contexto, é necessário alterar para aceitar mais de um.
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(
            CrudDddContext context)
        {
            _context = context;
        }

        public ITransaction Begin()
        {
            return new Transaction(_context);
        }
    }
}

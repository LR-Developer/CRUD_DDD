using CRUD_DDD.Domain.Contracts.Repositories;
using CRUD_DDD.Infra.Contexts;
using System.Data.Entity;

namespace CRUD_DDD.Infra.Repositories
{
    public class Transaction
        : ITransaction
    {
        /// <summary>
        /// Caso tenha mais de um contexto, é necessário alterar para aceitar mais de um.
        /// </summary>
        /// <param name="context"></param>
        public Transaction(
            CrudDddContext context)
        {
            _context = context;
            _contextTransaction = context.Database.BeginTransaction();
        }

        private readonly CrudDddContext _context;
        private readonly DbContextTransaction _contextTransaction;

        public void Commit()
        {
            _contextTransaction.Commit();
        }

        public void Rollback()
        {
            _contextTransaction.Rollback();
        }

        public void Dispose()
        {
            _contextTransaction.Dispose();
        }
    }
}

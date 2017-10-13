using System;

namespace CRUD_DDD.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        ITransaction Begin();
    }

    public interface ITransaction
        : IDisposable
    {
        void Commit();
        void Rollback();
    }
}

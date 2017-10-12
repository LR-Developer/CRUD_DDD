using System.Collections.Generic;

namespace CRUD_DDD.Domain.Contracts.Services
{
    public interface IServices<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}

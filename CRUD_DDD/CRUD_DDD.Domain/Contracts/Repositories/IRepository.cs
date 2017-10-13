using CRUD_DDD.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_DDD.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity>
        : IDisposable
        where TEntity : class, IAggregateRoot
    {
        TEntity Find(object key);
        IQueryable<TEntity> AsQueryable();

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);
        void UpdateRange(IEnumerable<TEntity> entities);
        void RemoveRange(IEnumerable<TEntity> entities);
    }

    /// <summary>
    /// Criei este repositório genérico por propriedades para mostrar outro cenário possível.
    /// </summary>
    public interface IRepository
    {
        TEntity Find<TEntity>(object key) where TEntity : class, IAggregateRoot;
        IQueryable<TEntity> AsQueryable<TEntity>() where TEntity : class, IAggregateRoot;

        void Add<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;
        void Update<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;
        void Remove<TEntity>(TEntity entity) where TEntity : class, IAggregateRoot;

        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IAggregateRoot;
        void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IAggregateRoot;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IAggregateRoot;
    }
}

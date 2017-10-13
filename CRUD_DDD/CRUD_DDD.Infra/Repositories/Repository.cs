using CRUD_DDD.Domain.Contracts.Entities;
using CRUD_DDD.Domain.Contracts.Repositories;
using CRUD_DDD.Infra.Contexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace CRUD_DDD.Infra.Repositories
{
    /// <summary>
    /// Repositório Genérico
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class Repository<TEntity>
        : IDisposable
        , IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        /// <summary>
        /// Comentei, para utilizar os conceitos do SOLID e DIP.
        ///     Desamarrei essa dependência para deixar para o IOC resolver.
        /// </summary>
        //private readonly CrudDddContext context = new CrudDddContext();

        private readonly CrudDddContext _context;

        protected Repository(
            CrudDddContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Entities => _context.Set<TEntity>();

        public void Add(TEntity obj)
        {
            Entities.Add(obj);

            //comentei, pois passei deixei a responsabilidade para o UnitOfWork
            //_context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return Entities.AsQueryable();
        }

        public TEntity Find(object key)
        {
            return Entities.Find(key);
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);

            //comentei, pois passei deixei a responsabilidade para o UnitOfWork
            //_context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;

            //comentei, pois passei deixei a responsabilidade para o UnitOfWork
            //_context.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
            => Entities.AddRange(entities);

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
            => Entities.RemoveRange(entities);
    }

    /// <summary>
    /// Opção de condições básicas encapsuladas
    /// </summary>
    public sealed class Repository
        : IRepository
    {
        private readonly CrudDddContext _context;

        public Repository(
            CrudDddContext context)
        {
            _context = context;
        }


        public DbSet<TEntity> SetEntity<TEntity>()
            where TEntity : class, IAggregateRoot => _context.Set<TEntity>();

        public void Add<TEntity>(TEntity entity)
            where TEntity : class, IAggregateRoot => SetEntity<TEntity>().Add(entity);

        public void AddRange<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IAggregateRoot
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public IQueryable<TEntity> AsQueryable<TEntity>()
            where TEntity : class, IAggregateRoot => SetEntity<TEntity>().AsQueryable();

        public TEntity Find<TEntity>(object key)
            where TEntity : class, IAggregateRoot => SetEntity<TEntity>().Find(key);

        public void Remove<TEntity>(TEntity entity)
            where TEntity : class, IAggregateRoot => SetEntity<TEntity>().Remove(entity);

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IAggregateRoot
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public void Update<TEntity>(TEntity entity)
            where TEntity : class, IAggregateRoot => _context.Entry(entity).State = EntityState.Modified;

        public void UpdateRange<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IAggregateRoot
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }
    }
}

using CRUD_DDD.Domain.Contracts.Repositories;
using CRUD_DDD.Domain.Contracts.Services;
using System;
using System.Collections.Generic;

namespace CRUD_DDD.Services
{
    public class Services<TEntity> : IDisposable, IServices<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Services(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
    }
}

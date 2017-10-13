using AutoMapper;
using CRUD_DDD.Domain.Contracts.Entities;
using CRUD_DDD.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_DDD.Services
{
    public abstract class ServiceBase<TEntity, TFindDto, TListDto, TAddDto, TUpdateDto>
        : IServiceBase<TFindDto, TListDto, TAddDto, TUpdateDto>
        where TEntity: class, IAggregateRoot
        where TFindDto : class
        where TListDto : class
        where TAddDto : class, IConvertToEntity<TEntity>
        where TUpdateDto : class, IApplyChangesTo<TEntity>
    {
        /// <summary>
        /// Protected para poder ler pelas heranças sem ter que ficar "reinjetando"
        /// </summary>
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IRepository<TEntity> Repository;

        public ServiceBase(
            IUnitOfWork unitOfWork,
            IRepository<TEntity> repository)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public virtual void Add(TAddDto dto)
        {
            var entity = dto.ConvertToEntity();

            using (var transaction = UnitOfWork.Begin())
            {
                try
                {
                    Repository.Add(entity);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public TFindDto Find(object key)
        {
            var entity = Repository.Find(key);
            return Mapper.Map<TFindDto>(entity);
        }

        public IEnumerable<TListDto> GetAll()
        {
            var entities = Repository.AsQueryable().ToList();
            return Mapper.Map<IEnumerable<TListDto>>(entities);
        }

        public void RemoveBy(object key)
        {
            var entity = Repository.Find(key);
            using (var transaction = UnitOfWork.Begin())
            {
                try
                {
                    Repository.Remove(entity);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Update(object key, TUpdateDto dto)
        {
            var entity = Repository.Find(key);
            dto.ApplyChangesTo(entity);

            using (var transaction = UnitOfWork.Begin())
            {
                try
                {
                    Repository.Update(entity);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}

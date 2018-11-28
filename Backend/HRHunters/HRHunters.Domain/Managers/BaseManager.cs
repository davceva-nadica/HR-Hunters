﻿using HRHunters.Common.Interfaces;
using HRHunters.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HRHunters.Domain.Managers
{
    public class BaseManager : IBaseManager
    { 
        private readonly IRepository _repo;
        public BaseManager(IRepository repo)
        {
            _repo = repo;
        }
        public void Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : class, IEntity
        {
            _repo.Create(entity, createdBy);
        }

        public void Delete<TEntity>(object id) where TEntity : class, IEntity
        {
            _repo.Delete<TEntity>(id);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
        {
            _repo.Delete(entity);
        }

        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class, IEntity
        {
            return _repo.Get(filter, orderBy, includeProperties, skip, take);
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class, IEntity
        {
            return _repo.GetAll(orderBy, includeProperties, skip, take);
        }

        public TEntity GetById<TEntity>(object id) where TEntity : class, IEntity
        {
            return _repo.GetById<TEntity>(id);
        }

        public int GetCount<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class, IEntity
        {
            return _repo.GetCount(filter);
        }

        public bool GetExists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class, IEntity
        {
            return _repo.GetExists(filter);
        }

        public TEntity GetOne<TEntity>(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null) where TEntity : class, IEntity
        {
            return _repo.GetOne(filter, includeProperties);
        }

        public void Save()
        {
            _repo.Save();
        }

        public void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class, IEntity
        {
            _repo.Update(entity, modifiedBy);
        }
    }
}

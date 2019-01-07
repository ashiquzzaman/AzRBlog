using AzRBlog.Entities;
using AzRBlog.Repositories;
using System;
using System.Collections.Generic;

namespace AzRBlog.Services
{
    public abstract class EntityManager<T> : IEntityManager<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public EntityManager(IRepository<T> repository)
        {
            _repository = repository;
        }


        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
            _repository.Save();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Edit(entity);
            _repository.Save();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _repository.Save();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}

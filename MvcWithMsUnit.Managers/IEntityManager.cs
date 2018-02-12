using MvcWithMsUnit.Entities;
using System.Collections.Generic;

namespace MvcWithMsUnit.Managers
{
    public interface IEntityManager<T> : IManager
        where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}

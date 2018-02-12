using MvcWithMsUnit.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcWithMsUnit.Repositories
{

    public interface IRepository<T> : IDisposable where T : BaseEntity
    {

        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        T Edit(T entity);
        int Save();

    }
}

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sample.Domain.Abstract
{
    public interface IEntityRepository<T> where T : class, new()
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}

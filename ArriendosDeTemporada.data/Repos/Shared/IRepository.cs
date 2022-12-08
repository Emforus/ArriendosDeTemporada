using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace ArriendosDeTemporada.data.Repos.Shared
{
    public interface IRepository<T> where T : class
    {
        T Get(object id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddMany(T[] ents);
        void Update(T entity);
        void Delete(T entity);
        void DeleteMany(T[] ents);
        IQueryable<T> GetAllQueryable();
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
    }
}

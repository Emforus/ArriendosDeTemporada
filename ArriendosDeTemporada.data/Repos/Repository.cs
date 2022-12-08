using System;
using System.Collections.Generic;
using System.Text;
using ArriendosDeTemporada.core.Models;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ArriendosDeTemporada.data.Repos
{
    public class Repository<T> : Shared.IRepository<T> where T : class
    {
        protected readonly DatabaseContext _context;
        private DbSet<T> entities;

        public Repository(DatabaseContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public T Get(object id)
        {
            return entities.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate);
        }

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Add(entity);
        }
        public void AddMany(T[] ents)
        {
            if (ents == null || ents.Length == 0) throw new ArgumentNullException("entity");
            entities.AddRange(ents);
        }
        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
        }
        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entities.Remove(entity);
        }
        public void DeleteMany(T[] ents)
        {
            if (ents == null || ents.Length == 0) throw new ArgumentNullException("entity");
            entities.RemoveRange(ents);
        }

        public IQueryable<T> GetAllQueryable()
        {
            return entities.AsQueryable<T>();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return entities.Where(predicate).AsQueryable();
        }


    }
}

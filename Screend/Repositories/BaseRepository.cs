using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Screend.Data;

namespace Screend.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll(); 
        DbSet<TEntity> GetSet();
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Commit();
    }
    
    public class BaseRepository<TEntity> where TEntity : class 
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query) : query;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.Select(row => row);
        }
        
        protected virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            var entity = _dbSet.FirstOrDefault(filter);

            return entity;
        }

        public virtual DbSet<TEntity> GetSet()
        {
            return _dbSet;
        }

        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Commit()
        {
            _context.SaveChanges();
        }
    }
   
}
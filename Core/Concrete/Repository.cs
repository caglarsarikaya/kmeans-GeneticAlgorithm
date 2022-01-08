using Core.Abstract;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
 

namespace Core.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly DbContext _context;
        public DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public  void Add(T entity)
        {
              _dbSet.Add(entity);
        }

        public  void AddRange(IEnumerable<T> entities)
        {
             _dbSet.AddRange(entities);
        }

        public  IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return  _dbSet.Where(predicate).ToList();
        }

        public  IEnumerable<T> GetAll()
        {
            return  _dbSet.ToList();
        }

        public  T GetById(int Id)
        {
            return  _dbSet.Find(Id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveById(int id)
        {
            var entity = _dbSet.Find(id);
            if(entity is not null)
            Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public  T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return  _dbSet.SingleOrDefault(predicate);
        }

        public T Update(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

    }
}
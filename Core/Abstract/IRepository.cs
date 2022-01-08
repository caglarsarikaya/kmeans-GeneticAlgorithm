using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public interface IRepository<T> where T : class
    {
        T GetById(int Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveById(int id);
        void RemoveRange(IEnumerable<T> entities);
        T Update(T entity);

    }
}

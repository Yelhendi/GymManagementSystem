using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GymManagementSystem.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
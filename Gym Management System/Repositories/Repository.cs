﻿using GymManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;



namespace GymManagementSystem.Repositories
{
    public class Repository<T> : IRepository <T> where T : class
    {
        //Set contect you want to use 
        protected AppDbContext  RepositoryContext { get; set; }
        //give constructor
        public Repository (AppDbContext repositoryContext)
        {
            repositoryContext = repositoryContext;
        }

        public T Create (T entity)
        {
            return RepositoryContext.Set<T>().Add(entity).Entity;
        }
        public void Delete (T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

            public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

       public T Update(T entity)
        {
            return RepositoryContext.Set<T>().Update(entity).Entity;
        }
    }
}

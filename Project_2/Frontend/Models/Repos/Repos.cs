using Frontend.Data;
using Frontend.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models.Repos
{
    [ExcludeFromCodeCoverage]
    public class Repos<T> : IRepository<T> where T:class
    {
        protected ApplicationDBContext RepositoryContext { get; set; }
        //Dependency injection for 'fake' db
        public Repos (ApplicationDBContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        //Implementing the methods in IRepository
        public IEnumerable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();

        }


        public T Create(T entity)
        {
            return RepositoryContext.Set<T>().Add(entity).Entity;
        }
    }
}

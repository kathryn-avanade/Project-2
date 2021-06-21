using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using System.Threading.Tasks;



namespace Frontend.Interfaces
{
    
    public interface IRepository<T>
    {
        //RepositoryPattern with generics
        IEnumerable<T> FindAll();
        T Create(T entity);
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GenericRepositoryPattern.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        DbSet<T> Table { get; }
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IQueryable<T> All();
        IQueryable<T> Where(Expression<Func<T, bool>> where);
        IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);
        T Single(Expression<Func<T, bool>> single);
        T FindById(object id);
    }
}

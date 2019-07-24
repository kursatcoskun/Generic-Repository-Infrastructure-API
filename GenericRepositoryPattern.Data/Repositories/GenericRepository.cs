using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPattern.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly Context context;
        public DbSet<T> Table { get; set; }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return Save();
        }

        public IQueryable<T> All()
        {
            return Table;
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return Save();
        }

        public T FindById(object id)
        {
            return Table.Find(id);
        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return Table.OrderByDescending(orderBy);
            return Table.OrderBy(orderBy);
        }

        public T Single(Expression<Func<T, bool>> single)
        {
            return Table.SingleOrDefault(single);
        }

        public bool Update(T entity)
        {
            Table.Update(entity);
            return Save();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return Table.Where(where);
        }

        public bool Save()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
                //You can implement your log library here.
                return false;
            }
        }
    }
}

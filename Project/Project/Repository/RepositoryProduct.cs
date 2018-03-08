using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
     class RepositoryProduct<Product> : IRepository<Product>
        where Product : class
    {
        protected DataContext Context = null;

        public RepositoryProduct()
        {
            this.Context = new DataContext();

        }
        public RepositoryProduct(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<Product> DbSet
        {
            get
            {
                return Context.Set<Product>();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
        public int Count
        {
            get
            {
                return DbSet.Count();
            }
        }

        public IQueryable<Product> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<Product, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public Product Create(Product Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<Product, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(Product t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<Product> Filter(Expression<Func<Product, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<Product>();
        }



        public Product Find(Expression<Func<Product, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(Product t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
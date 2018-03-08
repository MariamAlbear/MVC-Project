using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
    class RepositoryProductType<ProductType> : IRepository<ProductType>
        where ProductType : class
    {
        protected DataContext Context = null;

        public RepositoryProductType()
        {
            this.Context = new DataContext();

        }
        public RepositoryProductType(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<ProductType> DbSet
        {
            get
            {
                return Context.Set<ProductType>();
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

        public IQueryable<ProductType> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<ProductType, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public ProductType Create(ProductType Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<ProductType, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(ProductType t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<ProductType> Filter(Expression<Func<ProductType, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<ProductType>();
        }



        public ProductType Find(Expression<Func<ProductType, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(ProductType t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
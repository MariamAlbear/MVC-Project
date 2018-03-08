using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
     class RepositoryCategory<Category> : IRepository<Category>
        where Category : class
    {
        protected DataContext Context = null;

        public RepositoryCategory()
        {
            this.Context = new DataContext();

        }
        public RepositoryCategory(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<Category> DbSet
        {
            get
            {
                return Context.Set<Category>();
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

        public IQueryable<Category> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<Category, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public Category Create(Category Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<Category, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(Category t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<Category> Filter(Expression<Func<Category, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<Category>();
        }



        public Category Find(Expression<Func<Category, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(Category t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
     class RepositoryShop<Shop> : IRepository<Shop>
        where Shop : class
    {
        protected DataContext Context = null;
        
        public RepositoryShop()
        {
            this.Context = new DataContext();

        }
        public RepositoryShop(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<Shop> DbSet
        {
            get
            {
                return Context.Set<Shop>();
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

        public IQueryable<Shop> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<Shop, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public Shop Create(Shop Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<Shop, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(Shop t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<Shop> Filter(Expression<Func<Shop, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<Shop>();
        }



        public Shop Find(Expression<Func<Shop, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(Shop t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
    class RepositoryShopProducts<ShopProducts> : IRepository<ShopProducts>
        where ShopProducts : class
    {
        protected DataContext Context = null;

        public RepositoryShopProducts()
        {
            this.Context = new DataContext();

        }
        public RepositoryShopProducts(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<ShopProducts> DbSet
        {
            get
            {
                return Context.Set<ShopProducts>();
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

        public IQueryable<ShopProducts> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<ShopProducts, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public ShopProducts Create(ShopProducts Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<ShopProducts, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(ShopProducts t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<ShopProducts> Filter(Expression<Func<ShopProducts, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<ShopProducts>();
        }



        public ShopProducts Find(Expression<Func<ShopProducts, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(ShopProducts t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
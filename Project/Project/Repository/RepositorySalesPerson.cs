using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
     class RepositorySalesPerson<SalesPerson> : IRepository<SalesPerson>
        where SalesPerson : class
    {
        protected DataContext Context = null;

        public RepositorySalesPerson()
        {
            this.Context = new DataContext();

        }
        public RepositorySalesPerson(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<SalesPerson> DbSet
        {
            get
            {
                return Context.Set<SalesPerson>();
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

        public IQueryable<SalesPerson> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<SalesPerson, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public SalesPerson Create(SalesPerson Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<SalesPerson, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(SalesPerson t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<SalesPerson> Filter(Expression<Func<SalesPerson, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<SalesPerson>();
        }



        public SalesPerson Find(Expression<Func<SalesPerson, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(SalesPerson t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
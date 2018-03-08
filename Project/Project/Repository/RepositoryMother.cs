using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
    class RepositoryMother<Mother> : IRepository<Mother>
        where Mother : class
    {
        protected DataContext Context = null;

        public RepositoryMother()
        {
            this.Context = new DataContext();

        }
        public RepositoryMother(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<Mother> DbSet
        {
            get
            {
                return Context.Set<Mother>();
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

        public IQueryable<Mother> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<Mother, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public Mother Create(Mother Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<Mother, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(Mother t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<Mother> Filter(Expression<Func<Mother, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<Mother>();
        }



        public Mother Find(Expression<Func<Mother, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(Mother t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
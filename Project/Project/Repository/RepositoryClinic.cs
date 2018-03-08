using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
     class RepositoryClinic<Clinic> : IRepository<Clinic>
        where Clinic : class
    {
        protected DataContext Context = null;

        public RepositoryClinic()
        {
            this.Context = new DataContext();

        }
        public RepositoryClinic(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<Clinic> DbSet
        {
            get
            {
                return Context.Set<Clinic>();
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

        public IQueryable<Clinic> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<Clinic, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public Clinic Create(Clinic Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<Clinic, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(Clinic t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<Clinic> Filter(Expression<Func<Clinic, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<Clinic>();
        }



        public Clinic Find(Expression<Func<Clinic, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(Clinic t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
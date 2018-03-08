using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
     class RepositoryDoctor<Doctor> : IRepository<Doctor>
        where Doctor : class
    {
        protected DataContext Context = null;

        public RepositoryDoctor()
        {
            this.Context = new DataContext();

        }
        public RepositoryDoctor(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<Doctor> DbSet
        {
            get
            {
                return Context.Set<Doctor>();
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

        public IQueryable<Doctor> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<Doctor, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public Doctor Create(Doctor Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<Doctor, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(Doctor t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<Doctor> Filter(Expression<Func<Doctor, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<Doctor>();
        }



        public Doctor Find(Expression<Func<Doctor, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(Doctor t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
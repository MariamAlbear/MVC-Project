using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
    class RepositoryDoctorAnswer<DoctorAnswer> : IRepository<DoctorAnswer>
        where DoctorAnswer : class
    {
        protected DataContext Context = null;

        public RepositoryDoctorAnswer()
        {
            this.Context = new DataContext();

        }
        public RepositoryDoctorAnswer(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<DoctorAnswer> DbSet
        {
            get
            {
                return Context.Set<DoctorAnswer>();
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

        public IQueryable<DoctorAnswer> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<DoctorAnswer, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public DoctorAnswer Create(DoctorAnswer Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<DoctorAnswer, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(DoctorAnswer t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<DoctorAnswer> Filter(Expression<Func<DoctorAnswer, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<DoctorAnswer>();
        }



        public DoctorAnswer Find(Expression<Func<DoctorAnswer, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(DoctorAnswer t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
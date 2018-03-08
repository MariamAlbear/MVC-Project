using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Project.Repository
{
    class RepositoryQuestion<Question> : IRepository<Question>
        where Question : class
    {
        protected DataContext Context = null;

        public RepositoryQuestion()
        {
            this.Context = new DataContext();

        }
        public RepositoryQuestion(DataContext Context)
        {
            this.Context = Context;

        }

        protected DbSet<Question> DbSet
        {
            get
            {
                return Context.Set<Question>();
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

        public IQueryable<Question> All()
        {
            return DbSet.AsQueryable();
        }

        public bool Contains(Expression<Func<Question, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public Question Create(Question Permission)
        {
            var newEntry = DbSet.Add(Permission);
            Context.SaveChanges();
            return newEntry;
        }

        public int Delete(Expression<Func<Question, bool>> predicate)
        {
            var objects = Filter(predicate);
            foreach (var obj in objects)
                DbSet.Remove(obj);
            return Context.SaveChanges();

        }

        public int Delete(Question t)
        {
            DbSet.Remove(t);
            return Context.SaveChanges();

        }


        public IQueryable<Question> Filter(Expression<Func<Question, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<Question>();
        }



        public Question Find(Expression<Func<Question, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public int Update(Question t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            return Context.SaveChanges();

        }
    }
}
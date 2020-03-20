using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SPMigracao.Api.Domain;
using SPMigracao.Api.Infrastructure.Context;

namespace SPMigracao.Api.Infrastructure.Repositories
{
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MainContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected AbstractRepository(MainContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public void Dispose()
        {
            Db.Dispose();
        }
        public TEntity Add(TEntity obj)
        {
            DbSet.Add(obj);

            return obj;
        }

        public TEntity Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;

            return DbSet.Update(obj).Entity;
        }

        public void Delete(Guid id)
        {
            var obj = FindById(id);

            DbSet.Remove(obj);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual TEntity FindById(Guid id)
        {
            return DbSet.Find(id);
        }
        public IQueryable<TEntity> Query()
        {
            return DbSet.AsNoTracking();
        }

        public bool Commit()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
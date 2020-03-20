using System;
using System.Linq;

namespace SPMigracao.Api.Domain
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        void Delete(Guid id);
        void Remove(TEntity entity);
        TEntity FindById(Guid id);
        IQueryable<TEntity> Query();
        bool Commit();
    }
}
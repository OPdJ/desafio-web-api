using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Domain.Interfaces.Services.Common
{
    public interface IService<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Attach(TEntity entity);
        void DetachLocal(Func<TEntity, bool> predicate = null);
        void Update(TEntity entity, params object[] properties);
        void Delete(TEntity entity);
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
    }
}

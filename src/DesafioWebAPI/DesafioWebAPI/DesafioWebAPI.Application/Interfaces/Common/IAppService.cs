using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Application.Interfaces.Common
{
    public interface IAppService<TEntity> where TEntity : class
    {
        void Add(TEntity entityVM);
        void Update(TEntity entityVM, params object[] properties);
        void Delete(TEntity entityVM);
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
    }
}

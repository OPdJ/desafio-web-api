using DesafioWebAPI.Domain.Interfaces.Repositories.Common;
using DesafioWebAPI.Domain.Interfaces.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Domain.Services.Common
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Attach(TEntity entity)
        {
            _repository.Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void DetachLocal(Func<TEntity, bool> predicate)
        {
            _repository.DetachLocal(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _repository.GetAll();
        }

        public TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }

        public void Update(TEntity entity, params object[] properties)
        {
            _repository.Update(entity, properties);
        }
    }
}

using DesafioWebAPI.Domain.Interfaces.Repositories.Common;
using DesafioWebAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioWebAPI.Infra.Data.Repository.Common
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private readonly DesafioWebAPIContext _context;

        public Repository(DesafioWebAPIContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Attach(TEntity entity)
        {
            _context.Attach(entity);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DetachLocal(Func<TEntity, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity, params object[] properties)
        {
            if (properties.Length == 0)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                foreach (var property in properties)
                {
                    _context.Entry(entity).Property((string)property).IsModified = true;
                }
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

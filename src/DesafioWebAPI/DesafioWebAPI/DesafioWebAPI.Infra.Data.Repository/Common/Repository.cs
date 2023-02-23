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
            if (predicate == null)
            {
                var locals = _context.Set<TEntity>().Local.ToList();

                foreach (var local in locals)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }
            }
            else
            {
                var local = _context.Set<TEntity>().Local.Where(predicate).FirstOrDefault();

                if (local != null)
                    _context.Entry(local).State = EntityState.Detached;
            }
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
            DetachLocal();

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

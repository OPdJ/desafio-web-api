using DesafioWebAPI.Infra.Data.Context.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Infra.Data.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DesafioWebAPIContext _context;
        private IDbContextTransaction _trasaction;

        public UnitOfWork(DesafioWebAPIContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _trasaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _trasaction.Commit();
        }

        public void Rollback()
        {
            _trasaction.Rollback();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Infra.Data.Context.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void SaveChanges();
    }
}

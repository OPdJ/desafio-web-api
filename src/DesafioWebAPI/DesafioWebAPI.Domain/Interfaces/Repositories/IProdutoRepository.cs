using DesafioWebAPI.Domain.Entities;
using DesafioWebAPI.Domain.Interfaces.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DesafioWebAPI.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> GetBy(Expression<Func<Produto, bool>> predicate);
    }
}

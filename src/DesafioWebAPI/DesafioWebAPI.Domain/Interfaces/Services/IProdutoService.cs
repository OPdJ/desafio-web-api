using DesafioWebAPI.Domain.Entities;
using DesafioWebAPI.Domain.Interfaces.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DesafioWebAPI.Domain.Interfaces.Services
{
    public interface IProdutoService : IService<Produto>
    {
        IEnumerable<Produto> GetBy(Expression<Func<Produto, bool>> predicate);
    }
}

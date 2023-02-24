using DesafioWebAPI.Application.Interfaces.Common;
using DesafioWebAPI.Domain.Entities;
using DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DesafioWebAPI.Application.Interfaces
{
    public interface IProdutoAppService : IAppService<ProdutoViewModel>
    {
        IEnumerable<Produto> GetBy(Expression<Func<Produto, bool>> predicate);
    }
}

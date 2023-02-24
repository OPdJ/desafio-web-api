using DesafioWebAPI.Domain.Entities;
using DesafioWebAPI.Domain.Interfaces.Repositories;
using DesafioWebAPI.Domain.Interfaces.Services;
using DesafioWebAPI.Domain.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DesafioWebAPI.Domain.Services
{
    public class ProdutoService : Service<Produto>, IProdutoService
    {
        public readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Produto> GetBy(Expression<Func<Produto, bool>> predicate)
        {
            return _repository.GetBy(predicate);
        }
    }
}

using DesafioWebAPI.Domain.Entities;
using DesafioWebAPI.Domain.Interfaces.Repositories;
using DesafioWebAPI.Infra.Data.Context;
using DesafioWebAPI.Infra.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DesafioWebAPI.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private readonly DesafioWebAPIContext _context;

        public ProdutoRepository(DesafioWebAPIContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Produto> GetBy(Expression<Func<Produto, bool>> predicate)
        {
            return _context.Set<Produto>().Where(predicate).ToList();
        }
    }
}

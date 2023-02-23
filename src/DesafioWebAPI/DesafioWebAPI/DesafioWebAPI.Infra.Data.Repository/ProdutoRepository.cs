using DesafioWebAPI.Domain.Entities;
using DesafioWebAPI.Domain.Interfaces.Repositories;
using DesafioWebAPI.Infra.Data.Context;
using DesafioWebAPI.Infra.Data.Repository.Common;
using System;

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
    }
}

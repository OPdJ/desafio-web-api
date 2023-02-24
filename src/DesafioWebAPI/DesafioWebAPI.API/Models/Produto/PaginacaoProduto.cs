using DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI.API.Models.Produto
{
    public class PaginacaoProduto
    {
        public PaginacaoProduto(IEnumerable<ProdutoViewModel> produtos, int count, int numPagina, int prodsPorPagina)
        {
            PaginaInfo = new PaginaInfo
            {
                PaginaAtual = numPagina,
                ItensPorPagina = prodsPorPagina,
                TotalPaginas = (int)Math.Ceiling(count / (double)prodsPorPagina),
                TotalItens = count
            };

            this.Produtos = produtos;
        }

        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public PaginaInfo PaginaInfo { get; set; }

        public static PaginacaoProduto PaginarProduto(IEnumerable<ProdutoViewModel> produtos, int numPagina, int prodsPorPagina)
        {
            var count = produtos.Count();
            var chunk = produtos.Skip((numPagina - 1) * prodsPorPagina).Take(prodsPorPagina);
            return new PaginacaoProduto(chunk, count, numPagina, prodsPorPagina);
        }
    }
}

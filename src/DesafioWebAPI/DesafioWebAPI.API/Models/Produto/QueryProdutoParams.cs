using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI.API.Models.Produto
{
    public class QueryProdutoParams
    {
        private const int _maxPaginas = 50;

        private int _pagina = 10;

        public int Page { get; set; } = 1;

        public int ProdutoPorPagina
        {
            get
            {
                return _pagina;
            }
            set
            {
                if (value > _maxPaginas)
                {
                    _pagina = _maxPaginas;
                }
                else 
                { 
                    _pagina = value; 
                }
            }
        }

        public long Id { get; set; }
    }
}

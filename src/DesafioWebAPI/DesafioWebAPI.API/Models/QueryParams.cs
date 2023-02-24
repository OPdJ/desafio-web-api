using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI.API.Models.Produto
{
    public class QueryParams
    {
        private const int _maxPaginas = 50;

        private int _pagina = 10;

        public int Pagina { get; set; } = 1;

        public int ItemPorPagina
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

        //public string Descricao { get; set; }
        public bool? Situacao { get; set; }
        //public string FornecedorCNPJ { get; set; }
    }
}

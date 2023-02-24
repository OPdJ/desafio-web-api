using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI.API.Models
{
    public class PaginaInfo
    {
        public bool TemPaginaAnterior
        {
            get
            {
                return (PaginaAtual > 1);
            }
        }

        public bool TemProximaPagina
        {
            get
            {
                return (PaginaAtual < TotalPaginas);
            }
        }

        public int TotalPaginas { get; set; }
        public int PaginaAtual { get; set; }
        public int ItensPorPagina { get; set; }
        public int TotalItens { get; set; }
    }
}

using DesafioWebAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Domain.Entities
{
    public class Produto : DomainBase
    {
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime? Fabricacao { get; set; }
        public DateTime? Validade { get; set; }
        public long? FornecedorCodigo { get; set; }
        public string Fornecedor { get; set; }
        public string FornecedorCNPJ { get; set; }
    }
}

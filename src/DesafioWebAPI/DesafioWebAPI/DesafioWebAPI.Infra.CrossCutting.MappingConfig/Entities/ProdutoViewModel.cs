using DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities
{
    public class ProdutoViewModel : DomainBaseViewModel
    {
        public string Descricao { get; set; }
        public bool Situacao { get; set; } = true;
        public DateTime? Fabricacao { get; set; }
        public DateTime? Validade { get; set; }
        public long? FornecedorCodigo { get; set; }
        public string Fornecedor { get; set; }
        public string FornecedorCNPJ { get; set; }
    }
}

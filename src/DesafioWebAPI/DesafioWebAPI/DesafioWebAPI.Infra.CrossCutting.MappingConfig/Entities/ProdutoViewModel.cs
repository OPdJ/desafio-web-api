using DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities.Common;
using FoolProof.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities
{
    public class ProdutoViewModel : DomainBaseViewModel
    {
        [Required(ErrorMessage = "Campo Descrição precisa ser informado.")]
        public string Descricao { get; set; }
        public bool Situacao { get; set; } = true;
        [GreaterThanOrEqualTo("Validade", ErrorMessage = "Fabricação não pode ser maior ou igual a validade!")]
        public DateTime? Fabricacao { get; set; }
        public DateTime? Validade { get; set; }
        public long? FornecedorCodigo { get; set; }
        public string Fornecedor { get; set; }
        public string FornecedorCNPJ { get; set; }
        public string Status 
        {
            get 
            {
                return Situacao ? "Ativo" : "Inativo";
            }
        }
    }
}

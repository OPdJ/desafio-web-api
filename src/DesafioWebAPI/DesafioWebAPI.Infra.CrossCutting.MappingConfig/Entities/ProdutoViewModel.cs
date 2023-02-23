using DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities.Common;
using FoolProof.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DesafioWebAPI.Infra.CrossCutting.Utilities.ValidationAnnotations;

namespace DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities
{
    public class ProdutoViewModel : DomainBaseViewModel
    {
        [Required(ErrorMessage = "Campo Descrição precisa ser informado.")]
        [MaxLength(250, ErrorMessage = "Tamanho máx. de caracteres permitido são (250).")]
        public string Descricao { get; set; }
        public bool Situacao { get; set; } = true;
        [Comparison("Validade", ComparisonAttribute.ComparisonType.GreaterThanOrEqualTo, ErrorMessage = "Fabricação não pode ser maior ou igual a validade!")]
        public DateTime? Fabricacao { get; set; }
        public DateTime? Validade { get; set; }
        [MaxLength(100, ErrorMessage = "Tamanho máx. de caracteres permitido são (100).")]
        public string FornecedorCodigo { get; set; }
        [MaxLength(100, ErrorMessage = "Tamanho máx. de caracteres permitido são (100).")]
        public string Fornecedor { get; set; }
        [MaxLength(14, ErrorMessage = "Tamanho máx. de caracteres permitido são (14).")]
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

using AutoMapper;
using DesafioWebAPI.Domain.Entities;
using DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Infra.CrossCutting.MappingConfig.Configs
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}

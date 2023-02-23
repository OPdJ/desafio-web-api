using DesafioWebAPI.Application.Interfaces.Common;
using DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioWebAPI.Application.Interfaces
{
    public interface IProdutoAppService : IAppService<ProdutoViewModel>
    {
    }
}

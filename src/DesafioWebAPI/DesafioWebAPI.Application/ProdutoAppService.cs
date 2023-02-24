using AutoMapper;
using DesafioWebAPI.Application.Interfaces;
using DesafioWebAPI.Domain.Entities;
using DesafioWebAPI.Domain.Interfaces.Services;
using DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities;
using DesafioWebAPI.Infra.Data.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DesafioWebAPI.Application
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoService _service;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoService service, IUnitOfWork uow, IMapper mapper)
        {
            _service = service;
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(ProdutoViewModel entityVM)
        {
            var entity = _mapper.Map<Produto>(entityVM);
            _service.Add(entity);
            _uow.SaveChanges();
        }

        public void Delete(ProdutoViewModel entityVM)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            var entity = _service.GetAll();
            var entityVM = _mapper.Map<IEnumerable<ProdutoViewModel>>(entity);

            return entityVM;
        }

        public IEnumerable<Produto> GetBy(Expression<Func<Produto, bool>> predicate)
        {
            var entity = _service.GetBy(predicate);

            return entity;
        }

        public ProdutoViewModel GetById(long id)
        {
            var entity = _service.GetById(id);
            var entityVM = _mapper.Map<ProdutoViewModel>(entity);

            return entityVM;
        }

        public void Update(ProdutoViewModel entityVM, params object[] properties)
        {
            var entity = _mapper.Map<Produto>(entityVM);
            _service.Update(entity, properties);
            _uow.SaveChanges();
        }
    }
}

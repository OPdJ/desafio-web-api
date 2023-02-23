using DesafioWebAPI.Application.Interfaces;
using DesafioWebAPI.Infra.CrossCutting.MappingConfig.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioWebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _appService;

        public ProdutoController(IProdutoAppService appService)
        {
            _appService = appService;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_appService.GetAll());
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            return Ok(_appService.GetById(id));
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public ActionResult Post([FromBody] ProdutoViewModel entityVM)
        {
            if (entityVM == null)
                return NotFound();

            try
            {
                _appService.Add(entityVM);
            }
            catch (Exception ex)
            {
                //Logger
            }

            return Ok("Cadastro realizado com sucesso.");
        }

        // PUT api/<ProdutoController>/5
        [HttpPut]
        public ActionResult Put([FromBody] ProdutoViewModel entityVM)
        {
            if (entityVM == null)
                return NotFound();

            try
            {
                _appService.Update(entityVM);
            }
            catch (Exception ex)
            {
                //Logger
            }

            return Ok("Atualização realizada com sucesso.");
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] ProdutoViewModel entityVM)
        {
            if (entityVM == null)
                return NotFound();

            try
            {
                _appService.Update(entityVM);
            }
            catch (Exception ex)
            {
                //Logger
            }

            return Ok("Exclusão realizada com sucesso.");
        }
    }
}

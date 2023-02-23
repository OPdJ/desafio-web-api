using DesafioWebAPI.API.Controllers.Custom;
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
    public class ProdutoController : ControllerCustom
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
            if (entityVM.Fabricacao != null && entityVM.Validade != null)
            {
                if (entityVM.Fabricacao >= entityVM.Validade)
                {
                    ModelState.AddModelError(nameof(entityVM.Fabricacao), "Fabricação não pode ser maior ou igual a validade!");
                    return ValidationProblem();
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appService.Add(entityVM);

                    return Ok("Cadastro realizado com sucesso.");
                }
                catch (Exception ex)
                {
                    //Logger
                    return BadRequest($"{ex.Message}");
                }
            }

            return ValidationProblem();
        }

        // PUT api/<ProdutoController>/5
        [HttpPut]
        public ActionResult Put([FromBody] ProdutoViewModel entityVM)
        {
            if (entityVM == null)
                return NotFound();
            if (entityVM.Fabricacao != null && entityVM.Validade != null)
            {
                if (entityVM.Fabricacao >= entityVM.Validade)
                {
                    ModelState.AddModelError(nameof(entityVM.Fabricacao), "Fabricação não pode ser maior ou igual a validade!");
                    return ValidationProblem();
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _appService.Update(entityVM);

                    return Ok("Atualização realizada com sucesso.");
                }
                catch (Exception ex)
                {
                    //Logger
                    return BadRequest($"{ex.Message}");
                }
            }

            var errors = ModelError();

            return ValidationProblem();
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var entityVM = _appService.GetById(id);

                if (entityVM != null)
                {
                    entityVM.Situacao = false;
                    _appService.Update(entityVM);

                    return Ok("Exclusão lógica realizada com sucesso.");
                }
                else
                {
                    return Ok($"Não retornou nenhum item com o id: {id}.");
                }
            }
            catch (Exception ex)
            {
                //Logger
                return BadRequest($"{ex.Message}");
            }
        }
    }
}

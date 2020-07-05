using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CantinhoSalgado_API.Data;
using CantinhoSalgado_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CantinhoSalgado_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstoqueController : Controller
    {
        public IRepository _repo { get; }
        public EstoqueController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{OnlyWithEstoque}")]
        public async Task<IActionResult> Get(bool OnlyWithEstoque)
        {
            try
            {
                var result = await _repo.GetAllEstoque(OnlyWithEstoque);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Estoque model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/estoque/get/{model.EstoqueID}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            return BadRequest();
        }

        [HttpPut("{EstoqueID}/{qtd}")]
        public async Task<IActionResult> Put(int EstoqueID, int qtd)
        {
            try
            {
                var estoque = await _repo.GetEstoqueByID(EstoqueID);

                if (estoque == null) return NotFound();

                estoque.QtdEstoque = qtd;

                _repo.Update(estoque);

                if (await _repo.SaveChangesAsync())
                {
                    estoque = await _repo.GetEstoqueByID(EstoqueID);

                    return Created($"/estoque/{estoque.EstoqueID}", estoque);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            return BadRequest();
        }

        [HttpDelete("{ProdutoID}")]
        public IActionResult Delete(int ProdutoID)
        {
            try
            {
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }
    }
}
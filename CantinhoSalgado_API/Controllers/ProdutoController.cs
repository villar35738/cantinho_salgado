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
    public class ProdutoController : Controller
    {
        public IRepository _repo { get; }
        public ProdutoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllProdutos();

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto model)
        {
            try
            {
                _repo.Add(model);
                _repo.AddProdutoNoEstoque(model);


                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/produto/get/{model.ProdutoID}", model);
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete("{ProdutoID}")]
        public async Task<IActionResult> Delete(int ProdutoID)
        {
            try
            {
                var produto = await _repo.GetProdutoByID(ProdutoID);
                if (produto == null) return NotFound();

                _repo.Delete(produto);

                var estoque = await _repo.GetEstoqueByProduct(produto);
                if (estoque == null) return NotFound();
                _repo.Delete(estoque);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou: " + ex.Message);
            }
            return BadRequest();
        }

        [HttpPut("{ProdutoID}")]
        public IActionResult Put(int ProdutoID)
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
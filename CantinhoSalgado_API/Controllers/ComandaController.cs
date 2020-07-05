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
    [ApiController]
    [Route("[controller]")]
    public class ComandaController : Controller
    {
        public IRepository _repo { get; }
        public ComandaController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
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

        [HttpPost]
        public async Task<IActionResult> Post(Comanda comanda)
        {
            try
            {
                _repo.Add(comanda);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/comanda/get/", comanda);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(ComandaItens comandaItens)
        {
            try
            {
                _repo.Add(comandaItens);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/comanda/get/", comandaItens);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
            return BadRequest();
        }

        [HttpDelete("{ComandaID}")]
        public IActionResult Delete(int ComandaID)
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

        [HttpPut("{ComandaID}")]
        public IActionResult Put(int ComandaID)
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

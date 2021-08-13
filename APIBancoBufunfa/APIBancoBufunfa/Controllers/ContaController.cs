using APIBancoBufunfa.Data;
using APIBancoBufunfa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBancoBufunfa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private ContaContext _context;

        public ContaController(ContaContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult CriaConta([FromBody] Conta conta)
        {
            //Adicionando e salvando um objeto
            _context.Contas.Add(conta);
            _context.SaveChanges();

            //O primeiro parâmetro é a lógica de recuperar que deve ser usada, o segundo é a propriedade que deve ser herdada e o terceiro o objeto que está se referindo
            return CreatedAtAction(nameof(BuscaContaPorId), new { id = conta.Id }, conta);
        }

        [HttpGet]
        public IActionResult BuscaConta()
        {
            return Ok(_context.Contas);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaContaPorId(int id)
        {
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);

            if (conta != null)
            {
                return Ok(conta);
            }

            return NotFound($"A conta com o id {id} não pode ser achada!");
        }

        [HttpPut]
        public IActionResult AtualizaConta()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeletaConta()
        {
            return NoContent();
        }
    }
}

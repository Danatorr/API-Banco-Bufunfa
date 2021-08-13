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
    public class RendimentoController : ControllerBase
    {
        public double rendimento;
        private ContaContext _context;

        public RendimentoController(ContaContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult getRendimento(int id)
        {
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);

            if (conta != null)
            {
                //O valor de 0.002 equivale ao redimento da poupança em um mês.
                rendimento = conta.Saldo * 0.002;
                
                return Ok($"O rendimento mensal será de R$ {rendimento} caso não haja alteração no saldo.");
            }

            return NotFound($"A conta com Id {id} não pode ser achada!");
        }
    }
}

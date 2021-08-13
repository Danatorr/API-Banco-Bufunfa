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
    public class DepositoController : ControllerBase
    {
        private ContaContext _context;

        public DepositoController(ContaContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IActionResult Depositar(int id, int valor)
        {
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);

            if (conta != null)
            {
                conta.Saldo += valor;
                _context.SaveChanges();
                return NoContent();
            }

            return NotFound($"A conta com Id {id} não pode ser achada!");
        }
    }
}

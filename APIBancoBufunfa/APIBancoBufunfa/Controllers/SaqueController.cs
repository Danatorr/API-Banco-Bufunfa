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
    public class SaqueController : ControllerBase
    {
        private ContaContext _context;

        public SaqueController(ContaContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public IActionResult Sacar(int id, int valor)
        {
            Conta conta = _context.Contas.FirstOrDefault(conta => conta.Id == id);

            if (conta != null)
            {
                //Sei que alterar o valor direto é quase um crime contra POO, mas para simplificar fiz assim, talvez com mais tempo e estudo fosse possível fazer encapsulamento, etc.
                if (conta.Tipo == "2")
                {
                    if (conta.Saldo >= valor)
                    {
                        conta.Saldo -= valor;
                        _context.SaveChanges();
                        return NoContent();
                    }
                    else
                    {
                        return NotFound($"Esta conta não tem saldo suficiente!");
                    }
                }
                else if (conta.Tipo == "1")
                {
                    //O valor de 1.038 é referente ao saque com CPMF
                    if (conta.Saldo >= valor * 1.038)
                    {
                        conta.Saldo -= valor * 1.038;
                        _context.SaveChanges();
                        return NoContent();
                    }
                    else
                    {
                        return NotFound($"Esta conta não tem saldo suficiente!");
                    }
                }
            }
            return NotFound($"A conta com Id {id} não pode ser achada!");
        }
    }
}

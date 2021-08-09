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

        [HttpPost]
        public IActionResult CriaConta()
        {
            return NoContent();
        }

        [HttpGet]
        public IActionResult BuscaConta()
        {
            return Ok();
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

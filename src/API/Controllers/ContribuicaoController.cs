using System;
using System.Threading.Tasks;
using API.Data;
using Dominio;
using Dominio.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContribuicaoController : ControllerBase
    {
        private readonly Contexto db;

        public ContribuicaoController(Contexto db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var contribuicao = await db.Churras.Include(x => x.Participantes).SingleOrDefaultAsync(x => x.Id == id);
            return Ok(contribuicao);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] ContribuicaoDto contribuicaoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var participante = await db.Participantes.FirstOrDefaultAsync(x => x.Id == contribuicaoDto.ParticipanteId);

            if (participante is null)
            {
                return NotFound();
            }

            participante.PagarChurras(contribuicaoDto.ValorPago, contribuicaoDto.ComBebida);
            await db.SaveChangesAsync();

            return Ok();
        }
    }
}

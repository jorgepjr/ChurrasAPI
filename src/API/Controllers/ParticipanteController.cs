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
    public class ParticipanteController : ControllerBase
    {
        private readonly Contexto db;

        public ParticipanteController(Contexto db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var participantes = await db.Participantes.ToListAsync();
            return Ok(participantes);
        }

         [HttpGet]
         [Route("{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            var participante = await db.Participantes.FirstOrDefaultAsync(x=>x.Nome == nome);
            return Ok(participante);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParticipanteDto participanteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var churras = await db.Churras.FirstOrDefaultAsync(x => x.Id == participanteDto.ChurrasId);

            var participante = new Participante(participanteDto.Nome, participanteDto.ValorSugerido);
            churras.Adicionar(participante);
            await db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var participante = await db.Participantes.FirstOrDefaultAsync(x=>x.Id == id);

            if (id is null)
            {
                return NotFound();
            }

            var churras = await db.Churras.FirstOrDefaultAsync(x=>x.Id == participante.ChurrasId);
            churras.Remover(participante);
           
            await db.SaveChangesAsync();

            return Ok(true);
        }
    }
}

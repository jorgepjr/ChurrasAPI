﻿using System;
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
    public class ChurrasController : ControllerBase
    {
        private readonly Contexto db;

        public ChurrasController(Contexto db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var churras = await db.Churras
            .Include(x => x.Participantes)
            .ToListAsync();
            return Ok(churras);
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var churras = await db.Churras.FindAsync(id);
            return Ok(churras);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChurrasDto churrasDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var churras = new Churras(churrasDto.Descricao, churrasDto.Data, churrasDto.Observacao);

            if (churras.DataRetroativa())
            {
                return BadRequest("A data deve ser maior ou igual a de hoje");
            }
            await db.AddAsync(churras);
            await db.SaveChangesAsync();

            return Ok(churras);
        }
    }
}

using ApiFilme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFilme.Data;
using ApiFilme.Data.DTOs;
using AutoMapper;

namespace ApiFilme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RetornaFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            
            if (filme == null)
            {
                return NotFound();
            }

            ReadFilmeDTO filmeDto = _mapper.Map<ReadFilmeDTO>(filme);
            return Ok(filmeDto);
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            
            if (filme == null)
            {
                return NotFound();
            }
            
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeAtualizadoDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            
            if (filme == null)
            {
                return NotFound();
            }

            _mapper.Map(filmeAtualizadoDto, filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.API.Data;
using SchoolSys.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace SchoolSys.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly DataContext _context;

        public CursoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var cursos = await _context.Cursos.ToListAsync();
                return Ok(cursos);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Problemas ao buscar registros!");
            }
        }

        [HttpGet("{CursoId}")]
        public async Task<IActionResult> Get(int CursoId)
        {
            try
            {
                var curso = await _context.Cursos.FindAsync(CursoId);

                if (curso == null)
                    return NotFound();

                return Ok(curso);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Problemas ao buscar registro!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Curso curso)
        {
            try
            {
                _context.Cursos.Add(curso);
                await _context.SaveChangesAsync();
                return Created($"/api/curso/{curso.Id}", curso);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Problemas ao salvar registro!");
            }
        }

        [HttpPut("{CursoId}")]
        public async Task<IActionResult> Put(int CursoId, Curso curso)
        {
            try
            {
                if (CursoId != curso.Id)
                    return BadRequest();

                _context.Entry(curso).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Created($"/api/curso/{curso.Id}", curso);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Problemas ao alterar registro!");
            }
        }

        [HttpDelete("{CursoId}")]
        public async Task<IActionResult> Delete(int CursoId)
        {
            try
            {
                var curso = await _context.Cursos.FindAsync(CursoId);

                if (curso == null)
                    return NotFound();

                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Problemas ao deletar registro!");
            }
        }
    }
}
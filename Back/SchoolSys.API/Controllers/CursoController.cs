using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.API.Data;
using SchoolSys.API.Models;

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
        public IEnumerable<Curso> Get()
        {
            return _context.Cursos;
        }
    }
}
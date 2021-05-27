using Microsoft.EntityFrameworkCore;
using SchoolSys.API.Models;

namespace SchoolSys.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
        
    }
}
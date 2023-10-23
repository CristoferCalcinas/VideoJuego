using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication3.Contexto
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto(DbContextOptions<AplicacionContexto> options):base(options) { }
        public DbSet<Email> email { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<VideoJuegos> videoJuego { get; set; }
    }
}

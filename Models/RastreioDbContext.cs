using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Models
{
    public class RastreioDbContext : DbContext
    {
        public RastreioDbContext(DbContextOptions<RastreioDbContext> options) : base(options)
        {

        }

        public DbSet<Rastreio> Rastreio { get; set; }
    }
}

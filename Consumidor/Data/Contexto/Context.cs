using Consumidor.Data.Modelo;

using Microsoft.EntityFrameworkCore;


namespace Consumidor.Data.Contexto
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opts) : base(opts)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
        public DbSet<UsuarioDB> Noticia { get; set; }
    }
}

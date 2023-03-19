using ApiLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLivros.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<ListaDesejo> ListaDesejos { get; set; }
    }
}

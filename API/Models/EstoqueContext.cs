using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ESTOQUE> Estoques { get; set; }
    }
}

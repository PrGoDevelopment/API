using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class T_ESTOQUE_Context : DbContext
    {
        public T_ESTOQUE_Context(DbContextOptions<T_ESTOQUE_Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<T_ESTOQUE> Estoques { get; set; }
    }
}

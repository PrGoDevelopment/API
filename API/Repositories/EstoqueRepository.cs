using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class EstoqueRepository : IEstoqueRepository
    {
        public readonly EstoqueContext _context;

        public EstoqueRepository(EstoqueContext context)
        {
            _context = context;
        }
        public async Task<ESTOQUE> Create(ESTOQUE estoque)
        {
            _context.Estoques.Add(estoque);
            await _context.SaveChangesAsync();

            return estoque;
        }

        public async Task Delete(int id)
        {
            var estoqueDelete = await _context.Estoques.FindAsync(id);
            _context.Estoques.Remove(estoqueDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ESTOQUE>> Get()
        {
            return await _context.Estoques.ToListAsync();
        }

        public async Task<ESTOQUE> Get(int id)
        {
            return await _context.Estoques.FindAsync(id);
        }

        public async Task Update(ESTOQUE estoque)
        {
            _context.Entry(estoque).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
